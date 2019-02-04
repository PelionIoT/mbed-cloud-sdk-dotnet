namespace Mbed.Cloud.Foundation.Common
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// AsyncHelper
    /// </summary>
    public static class AsyncHelper
    {
        private static readonly TaskFactory TaskFactory = new TaskFactory(
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

        /// <summary>
        /// Useful for test server
        /// </summary>
        /// <param name="task"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static TResult RunSyncWrap<TResult>(Task<TResult> task)
        {
            return RunSync<TResult>(() => task);
        }

        /// <summary>
        /// Useful for test server
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static void RunSyncWrapVoid(Task task)
        {
            RunSync(() => task);
        }

        /// <summary>
        /// Runs the synchronize.
        /// </summary>
        /// <param name="func">The function.</param>
        public static void RunSync(Func<Task> func)
            => TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        /// <summary>
        /// Runs the synchronize.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="func">The function.</param>
        /// <returns>result</returns>
        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => TaskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}