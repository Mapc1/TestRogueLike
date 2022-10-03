using UnityEngine;

namespace TestRogueLike.World.Items
{
    public class ItemAssets : MonoBehaviour
    {
        public static ItemAssets Instance { get; private set; }
    
        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        public GameObject pistolModel;
        public Sprite pistolIcon;
        
        public GameObject assaultRifleModel;
        public Sprite assaultRifleIcon;

        public GameObject shotgunModel;
        public Sprite shotgunIcon;
    }
}
