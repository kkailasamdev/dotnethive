using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetHive.Helpers.Retrier
{
    public class Retrier : IRetrier
    {
        private readonly int _maxRetries;
        private readonly double _delayBetweenRetriesInSeconds;
        private readonly Dictionary<Type, Func<bool>> _exceptionCallbacksByType;

        public Retrier(int maxRetries, double delayBetweenRetriesInSeconds)
        {
            _maxRetries = maxRetries;
            _delayBetweenRetriesInSeconds = delayBetweenRetriesInSeconds;
            _exceptionCallbacksByType = new Dictionary<Type, Func<bool>>();
        }

        public IRetrier RegisterExceptionCallback<TException>(Func<bool> callback) where TException : Exception
        {
            _exceptionCallbacksByType.Add(typeof(TException), callback);
            return this;
        }

        public async Task ExecuteAsync(Func<Task> actionToExecute)
        {
            int retryCount = 0;
            while (true)
            {
                try
                {
                    await actionToExecute();
                    return;
                }
                catch (Exception e)
                {
                    // throw if there are no corresponding callbacks (or) reached max retries.
                    if (!_exceptionCallbacksByType.TryGetValue(e.GetType(), out var exceptionCallback) || retryCount >= _maxRetries)
                    {
                        throw;
                    }
                    // the return bool value indicates whether to continue with retries or not.
                    var continueExecution = exceptionCallback();
                    if (!continueExecution)
                    {
                        throw;
                    }
                    retryCount++;
                    // exponential back-off i.e. the duration to wait between retries based on the current retry attempt.
                    await Task.Delay(TimeSpan.FromSeconds(_delayBetweenRetriesInSeconds * retryCount));
                }
            }
        }
    }
}
