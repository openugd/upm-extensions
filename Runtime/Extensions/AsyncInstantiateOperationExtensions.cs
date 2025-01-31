using System.Threading.Tasks;

namespace UnityEngine
{
    public static class AsyncInstantiateOperationExtensions
    {
        public static async Task<T[]> AsTask<T>(this AsyncInstantiateOperation<T> operation) where T : Object
        {
            var taskCompletionSource = new TaskCompletionSource<T[]>();
            if (operation.isDone)
            {
                taskCompletionSource.SetResult(operation.Result);
            }
            else
            {
                void OnOperationOnCompleted(AsyncOperation asyncOperation)
                {
                    operation.completed -= OnOperationOnCompleted;
                    taskCompletionSource.SetResult(operation.Result);
                }

                operation.completed += OnOperationOnCompleted;
            }

            return await taskCompletionSource.Task;
        }
    }
}
