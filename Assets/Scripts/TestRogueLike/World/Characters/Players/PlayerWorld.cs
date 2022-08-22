using System;
using TestRogueLike.Common;
using TestRogueLike.Exceptions.Characters.Players;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.Game.Items;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.World.Characters.Players
{
    public class PlayerWorld : MonoBehaviour
    {
        public const int LAYER = 8;
        
        private const float Speed = 5.0f;
    
        [SerializeField] private int maxHP;
        [SerializeField] private Transform weaponHolder;
    
        private Rigidbody _rigidbody;
    
        private float _verticalInput;
        private float _horizontalInput;
        private int _equipWeaponButtonPressed;
        private bool _interactButtonPressed;
    
        private Vector3 _lookPos;

        private Player _player;
        private ItemWorld equippedItemWorld;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = new Player(maxHP, new Pistol());
            equippedItemWorld = _player._inventory.GetActiveItem().PlaceItem(weaponHolder);
        }

        private void Update()
        {
            if (Input.GetButtonDown("Equip Weapon 1"))
                _equipWeaponButtonPressed = 0;
            else if (Input.GetButtonDown("Equip Weapon 2"))
                _equipWeaponButtonPressed = 1;
            else if (Input.GetButtonDown("Equip Weapon 3"))
                _equipWeaponButtonPressed = 2;
            else if (Input.GetButtonDown("Equip Weapon 4"))
                _equipWeaponButtonPressed = 3;
            else if (Input.GetButtonDown("Equip Weapon 5"))
                _equipWeaponButtonPressed = 4;
            else if (Input.GetButtonDown("Equip Weapon 6"))
                _equipWeaponButtonPressed = 5;
            else if (Input.GetButtonDown("Equip Weapon 7"))
                _equipWeaponButtonPressed = 6;
            else if (Input.GetButtonDown("Equip Weapon 8"))
                _equipWeaponButtonPressed = 7;
            else if (Input.GetButtonDown("Equip Weapon 9"))
                _equipWeaponButtonPressed = 8;
            if (Input.GetButtonDown("Interact"))
            {
                _interactButtonPressed = true;
                Debug.Log(_interactButtonPressed);
                
            }

            _verticalInput = Input.GetAxis("Vertical");
            _horizontalInput = Input.GetAxis("Horizontal");

            _lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_horizontalInput, 0, _verticalInput) * Speed;
            _rigidbody.transform.LookAt(new Vector3(_lookPos.x, _rigidbody.position.y, _lookPos.z));

            if (_equipWeaponButtonPressed != -1)
            {
                SwitchEquippedWeapon(_equipWeaponButtonPressed);
                _equipWeaponButtonPressed = -1;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer != Interactable.LAYER || !_interactButtonPressed) 
                return;
            
            var target = other.gameObject.GetComponentInParent<Interactable>();
            target.Interact(this);
            _interactButtonPressed = false;
        }

        private void SwitchEquippedWeapon(int index)
        {
            try
            {
                var item = _player._inventory.SwitchActiveItem(index);
                Destroy(equippedItemWorld.gameObject);
                equippedItemWorld = item.PlaceItem(weaponHolder);
            }
            catch (IndexGreaterThanHotbarSize msg)
            {
                Debug.Log(msg);
            }
        }

        public void AddItem(Item item)
        {
            _player._inventory.AddItem(item);
        }
    }
}
