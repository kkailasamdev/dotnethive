using System;
using System.Diagnostics;

namespace DotNetHive.Helpers
{
    public class ExecutionTimeLogger : IDisposable
    {
        private readonly Stopwatch _stopwatch;
        private readonly ILogger _logger;
        private readonly string _region;

        public static ExecutionTimeLogger NewScope(ILogger logger, string region)
        {
            return new ExecutionTimeLogger(logger, region); // returns new instance of ExecutionTimeLogger.
        }

        private ExecutionTimeLogger(ILogger logger, string region) // activator.
        {
            _logger = logger;
            _region = region;
            _logger.Log($"Started performance capture for: {_region}");
            (_stopwatch = new Stopwatch()).Start();
        }

        public void Dispose() // deactivator.
        {
            _stopwatch.Stop();
            _logger.Log($"Completed performance capture for: {_region}; time taken: {_stopwatch.Elapsed.Duration()}");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
