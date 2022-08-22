using System;
using System.Collections.Generic;
using TestRogueLike.Game.Items;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Characters.Players;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestRogueLike.World.Chests
{
    public class NormalChest : Chest
    {
        private static readonly List<Type> LOOT_OPTIONS = new()
        {
            typeof(Pistol),
            typeof(AssaultRifle)
        };
        
        private void Start()
        {
            loot = Random.Range(0, LOOT_OPTIONS.Count);
            Debug.Log(loot);
            
            isOpened = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer != PlayerWorld.LAYER || isOpened) 
                return;
            
            other.gameObject
                .GetComponent<PlayerWorld>()
                .AddItem((Item) Activator.CreateInstance(LOOT_OPTIONS[loot]));
            isOpened = true;
        }
    }
}