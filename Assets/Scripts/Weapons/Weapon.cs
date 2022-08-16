using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float attackCooldown;
        [SerializeField] protected AudioClip attackSound;
        
        protected AudioSource audioSource;
        protected Transform transform;
        
        protected float nextAttackTime;
        
        protected bool attackButtonPressed;
        protected bool reloadButtonPressed;
        
        protected abstract void Attack();
    }
}