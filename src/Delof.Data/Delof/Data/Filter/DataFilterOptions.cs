using System;
using System.Collections.Generic;

namespace Delof.Data.Filter
{
    public  class DataFilterOptions
    {
        public Dictionary<Type,DataFilterState> DefaultStates { get; }

        public DataFilterOptions()
        {
            DefaultStates = new Dictionary<Type, DataFilterState>();
        }
    }
}
