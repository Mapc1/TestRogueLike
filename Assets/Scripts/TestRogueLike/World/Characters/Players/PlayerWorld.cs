using TestRogueLike.Game.Characters.Players;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.World.Characters.Players
{
    public class PlayerWorld : MonoBehaviour
    {
        private const float Speed = 5.0f;
    
        [SerializeField] private int maxHP;
        [SerializeField] private Transform weaponHolder;
    
        private Rigidbody _rigidbody;
    
        private float _verticalInput;
        private float _horizontalInput;
        private bool _equipWeapon1Pressed;
        private bool _equipWeapon2Pressed;
    
        private Vector3 _lookPos;

        private Player _player;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _player = new Player(maxHP, new Pistol());
            PlaceWeapon();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Equip Weapon 1"))
                _equipWeapon1Pressed = true;
            else if (Input.GetButtonDown("Equip Weapon 2"))
                _equipWeapon2Pressed = true;
        
            _verticalInput = Input.GetAxis("Vertical");
            _horizontalInput = Input.GetAxis("Horizontal");

            _lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_horizontalInput, 0, _verticalInput) * Speed;
            _rigidbody.transform.LookAt(new Vector3(_lookPos.x, _rigidbody.position.y, _lookPos.z));

            if (_equipWeapon1Pressed)
            {
                SwitchEquippedWeapon(0);
                _equipWeapon1Pressed = false;
            }
            else if (_equipWeapon2Pressed)
            {
                SwitchEquippedWeapon(1);
                _equipWeapon2Pressed = false;
            }
        }

        private void PlaceWeapon()
        {
            var item = _player._inventory.GetActiveItem();
            item.PlaceItem(weaponHolder);
        }

        private void SwitchEquippedWeapon(int index)
        {
            _player._inventory.SwitchActiveItem(index);
            PlaceWeapon();
        }
    }
}
