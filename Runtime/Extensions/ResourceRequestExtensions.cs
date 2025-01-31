using System.Threading.Tasks;

namespace UnityEngine
{
    public static class ResourceRequestExtensions
    {
        public static async Task<T> AsTask<T>(this ResourceRequest request) where T : Object
        {
            var taskCompletionSource = new TaskCompletionSource<T>();
            if (request.isDone)
            {
                taskCompletionSource.SetResult((T)request.asset);
            }
            else
            {
                void OnRequestOnCompleted(AsyncOperation operation)
                {
                    request.completed -= OnRequestOnCompleted;
                    taskCompletionSource.SetResult((T)request.asset);
                }

                request.completed += OnRequestOnCompleted;
            }

            return await taskCompletionSource.Task;
        }
    }
}
