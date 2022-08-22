using TestRogueLike.Game.Items.Weapons;
using TMPro;
using UnityEngine;

namespace TestRogueLike.World.Items.Weapons
{
    public abstract class WeaponWorld : ItemWorld
    {
        [SerializeField] protected AudioClip attackSound;
        
        protected float nextAttackTime;
        
        protected bool attackButtonPressed;

        protected abstract void Attack();
    }
}