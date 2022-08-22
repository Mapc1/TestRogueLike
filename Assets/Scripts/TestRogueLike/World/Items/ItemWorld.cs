using System;
using TestRogueLike.Game.Items;
using UnityEngine;

namespace TestRogueLike.World.Items
{
    public abstract class ItemWorld : MonoBehaviour
    {
        protected Transform _transform;
        protected AudioSource _audioSource;
        
        protected Item _item;

        public void SetItem(Item item)
        {
            _item = item;
        }
    }
}