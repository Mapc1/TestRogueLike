using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.Game.Items
{
    public class Item
    {
        public readonly string name;
        public GameObject mesh { get; private set; }
        public Sprite icon;

        public virtual void Use()
        {
            Debug.Log("Using " + name);
        }

        protected Item(string name, GameObject mesh, Sprite icon)
        {
            this.name = name;
            this.mesh = mesh;
            this.icon = icon;
        }
        
        public ItemWorld PlaceItem(Transform parent)
        {
            var gameObject = Object.Instantiate(mesh, Vector3.zero, Quaternion.identity);
            gameObject.transform.SetParent(parent, false);
            
            var script = gameObject.GetComponent<ItemWorld>();
            script.SetItem(this);

            gameObject.SetActive(true);
            return script;
        }
    }
}