using System.Threading.Tasks;

namespace DotNetHive.DesignPatterns.Decorator
{
    public class Executor : IExecutor
    {
        public async Task Execute() => await Task.Delay(100).ConfigureAwait(false);
    }
}
