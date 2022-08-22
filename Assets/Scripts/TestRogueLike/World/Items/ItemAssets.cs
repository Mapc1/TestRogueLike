using UnityEngine;

namespace TestRogueLike.World.Items
{
    public class ItemAssets : MonoBehaviour
    {
        public static ItemAssets Instance { get; private set; }
    
        private void Awake()
        {
            Instance = this;
        }

        public GameObject pistolModel;
        public GameObject assaultRifleModel;
    }
}
