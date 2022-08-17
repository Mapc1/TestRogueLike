using TMPro;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float attackCooldown;
        [SerializeField] protected AudioClip attackSound;
        [SerializeField] protected TextMeshProUGUI ammoText;
        [SerializeField] protected TextMeshProUGUI nameText;

        public string weaponName;
        
        protected AudioSource audioSource;
        protected Transform transform;
        
        protected float nextAttackTime;
        
        protected bool attackButtonPressed;
        protected bool reloadButtonPressed;

        public abstract void init();
        protected abstract void Attack();
        public abstract void UpdateUI();
    }
}