using System.Threading;

namespace Homo.Threading
{
    public class NullableCancellationTokenProvider : ICancellationTokenProvider
    {
        public CancellationToken Token { get; } = CancellationToken.None;
    }
}
