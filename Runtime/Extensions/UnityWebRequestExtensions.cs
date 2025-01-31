using System.Threading.Tasks;
using UnityEngine.Networking;

namespace UnityEngine
{
    public static class UnityWebRequestExtensions
    {
        public static async Task<UnityWebRequest.Result> AsTask(this UnityWebRequestAsyncOperation reqOp)
        {
            while (!reqOp.isDone)
            {
                await Task.Yield();
            }

            return reqOp.webRequest.result;
        }
    }
}
