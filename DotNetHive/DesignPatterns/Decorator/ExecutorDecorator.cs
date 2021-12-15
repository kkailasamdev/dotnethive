using System.Diagnostics;
using System.Threading.Tasks;

namespace DotNetHive.DesignPatterns.Decorator
{
    public class ExecutorDecorator : IExecutor
    {
        private readonly IExecutor _executor;
        private readonly ILogger _logger;
        public ExecutorDecorator(IExecutor executor, ILogger logger)
        {
            _executor = executor;
            _logger = logger;
        }

        public async Task Execute()
        {
            var sw = Stopwatch.StartNew();
            await _executor.Execute().ConfigureAwait(false);
            sw.Stop();
            _logger.Log($"Elapsed: {sw.Elapsed.TotalSeconds}");
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
