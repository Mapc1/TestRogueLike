using System;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons
{
    public class Weapon : Item 
    {
        public int damage { get; private set; }
        public float attackCooldown { get; private set; }
        
        protected Weapon(string name, GameObject mesh, int damage, float attackCooldown) : base(name, mesh)
        {
            this.damage = damage;
            this.attackCooldown = attackCooldown;
        }
    }
}