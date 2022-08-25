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
        private void Awake()
        {
            lootOptions = new List<Type>
            {
                //typeof(Pistol),
                typeof(AssaultRifle)
            };
        }

        private void Start()
        {
            loot = Random.Range(0, lootOptions.Count);
            isOpened = false;
        }
    }
}