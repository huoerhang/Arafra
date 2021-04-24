using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Andef.DependencyInjection;

namespace Andef.Data.Filter
{
    [Dependency]
    public class DataFilter : IDataFilter
    {
        private readonly ConcurrentDictionary<Type, object> _filters;
        private readonly IServiceProvider _serviceProvider;

        public DataFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _filters = new ConcurrentDictionary<Type, object>();
        }

        public IDisposable Enable<TFilter>()
            where TFilter : class
        {
            return GetFilter<TFilter>().Enable();
        }

        public IDisposable Disable<TFilter>()
            where TFilter : class
        {
            return GetFilter<TFilter>().Disable();
        }

        public bool IsEnabled<TFilter>()
            where TFilter : class
        {
            return GetFilter<TFilter>().IsEnable;
        }

        private IDataFilter<TFilter> GetFilter<TFilter>()
            where TFilter : class
        {
            return _filters.GetOrAdd(typeof(TFilter), () => _serviceProvider.GetRequiredService<IDataFilter<TFilter>>()) as IDataFilter<TFilter>;
        }
    }

    public class DataFilter<TFilter> : IDataFilter<TFilter>
        where TFilter : class
    {
        private readonly DataFilterOptions _options;
        private readonly AsyncLocal<DataFilterState> _filterState;

        public bool IsEnable
        {
            get
            {
                EnsureInitialized();

                return _filterState.Value.IsEnabled;
            }
        }

        public DataFilter(IOptions<DataFilterOptions> options)
        {
            options.CheckNotNull(nameof(options));
            _options = options.Value;
            _filterState = new AsyncLocal<DataFilterState>();
        }


        public IDisposable Enable()
        {
            if (IsEnable)
            {
                return NullableDisposable.Instance;
            }

            _filterState.Value.IsEnabled = true;

            return new DisposeAction(() => Disable());
        }

        public IDisposable Disable()
        {
            if (!IsEnable)
            {
                return NullableDisposable.Instance;
            }

            _filterState.Value.IsEnabled = false;

            return new DisposeAction(() => Enable());
        }

        private void EnsureInitialized()
        {
            if (_filterState.Value != null)
            {
                return;
            }

            _filterState.Value = _options.DefaultStates.GetOrDefault(typeof(TFilter))?.Clone() ?? new DataFilterState(true);
        }
    }
}
