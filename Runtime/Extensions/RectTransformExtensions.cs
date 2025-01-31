namespace UnityEngine
{
    public static class RectTransformExtensions
    {
        private static readonly Vector3[] _worldCorners = new Vector3[4];

        public static Rect GetWorldRect(this RectTransform transform)
        {
            transform.GetWorldCorners(_worldCorners);
            var result = new Rect(
                _worldCorners[0].x,
                _worldCorners[0].y,
                _worldCorners[2].x - _worldCorners[0].x,
                _worldCorners[2].y - _worldCorners[0].y);
            return result;
        }
    }
}
