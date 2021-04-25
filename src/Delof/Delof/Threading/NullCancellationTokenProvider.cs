﻿using System.Threading;

namespace Delof.Threading
{
    public class NullCancellationTokenProvider : ICancellationTokenProvider
    {
        public static NullCancellationTokenProvider Instance { get; } = new NullCancellationTokenProvider();

        public CancellationToken Token { get; } = CancellationToken.None;

        private NullCancellationTokenProvider()
        {

        }
    }
}
