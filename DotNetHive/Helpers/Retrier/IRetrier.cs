using System;
using System.Threading.Tasks;

namespace DotNetHive.Helpers.Retrier
{
    public interface IRetrier
    {
        Task ExecuteAsync(Func<Task> actionToExecute);
        IRetrier RegisterExceptionCallback<TException>(Func<bool> callback) where TException : Exception;
    }
}