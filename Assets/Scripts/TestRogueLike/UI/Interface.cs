using UnityEngine;

namespace TestRogueLike.UI
{
    public class Interface : MonoBehaviour
    {
        public static Interface Instance;
        
        public Canvas Canvas { get; private set; }
        public RectTransform ItemCursor;

        private void Awake()
        {
            Canvas = GetComponent<Canvas>();
            Instance = this;
        }
    }
}