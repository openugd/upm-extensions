namespace UnityEngine
{
    public static class GameObjectExtensions
    {
        public static void Destroy(this UnityEngine.GameObject gameObject)
        {
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(gameObject);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(gameObject);
            }
        }

        public static void DestroyGameObject(this UnityEngine.MonoBehaviour component)
        {
            if (component == null || component.destroyCancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(component.gameObject);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(component.gameObject);
            }
        }

        public static void DestroyGameObject(this UnityEngine.Component component)
        {
            if (component == null)
            {
                return;
            }

            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(component.gameObject);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(component.gameObject);
            }
        }

        public static void DontDestroyOnLoad(this UnityEngine.GameObject gameObject)
        {
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
        }

        public static void DontDestroyOnLoad(this UnityEngine.Component component)
        {
            UnityEngine.Object.DontDestroyOnLoad(component.gameObject);
        }
    }
}