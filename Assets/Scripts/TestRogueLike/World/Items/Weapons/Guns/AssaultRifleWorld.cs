using TestRogueLike.Game.Items.Weapons.Guns;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public class AssaultRifleWorld : GunWorld
    {
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _audioSource = GetComponent<AudioSource>();
        }
        private void Update()
        {
            if (InventoryUI.Instance.IsInventoryOpen)
                return;
            
            if (Input.GetButtonDown("Fire1"))
                attackButtonPressed = true;
            else if (Input.GetButtonUp("Fire1"))
                attackButtonPressed = false;
            else if (Input.GetButtonDown("Reload"))
                ReloadButtonPressed = true;
        }
        
        private void FixedUpdate()
        {
            if (attackButtonPressed)
                Attack();
            else if (ReloadButtonPressed)
            {
                Reload();
                ReloadButtonPressed = false;
            }
        }
    }
}