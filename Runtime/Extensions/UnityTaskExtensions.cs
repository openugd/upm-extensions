using System;
using System.Threading.Tasks;

namespace UnityEngine
{
    /// <summary>
    /// It provides a way to delay a task for a certain amount of time.
    /// Use for WebGL, because Task.Delay is not supported.
    /// </summary>
    public static class TaskDelay
    {
        /// <summary>
        /// Use for WebGL, because Task.Delay is not supported.
        /// </summary>
        /// <param name="delay"></param>
        public static async Task Delay(TimeSpan delay)
        {
            var startTime = Time.time;
            while (startTime + delay.TotalSeconds >= Time.time)
            {
                await Task.Yield();
            }
        }

        /// <summary>
        /// Use for WebGL, because Task.Delay is not supported.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static Task AsTaskDelay(this TimeSpan delay) => Delay(delay);
    }
}
