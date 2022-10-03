using System;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons
{
    public abstract class Weapon : Item 
    {
        public int damage { get; private set; }
        public float attackCooldown { get; private set; }
        
        protected Weapon(string name, GameObject mesh, Sprite icon, int damage, float attackCooldown) : base(name, mesh, icon)
        {
            this.damage = damage;
            this.attackCooldown = attackCooldown;
        }
    }
}