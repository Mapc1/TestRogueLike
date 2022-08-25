using TestRogueLike.Common;
using TestRogueLike.Exceptions.Characters.Players;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.Game.Items;
using TestRogueLike.Game.Items.Weapons.Guns;
using TestRogueLike.World.Items;
using UnityEngine;
using UnityEngine.EventSystems;

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

        public Player Player { get; private set; }
        private ItemWorld _equippedItemWorld;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            Player = new Player(maxHP, new Pistol());
            _equippedItemWorld = Inventory.Instance.GetActiveItem().PlaceItem(weaponHolder);

            Inventory.Instance.OnActiveItemChangedCallback += PlaceItemWorld;
        }

        private void Update()
        {
            if (InventoryUI.Instance.IsInventoryOpen)
                return;
            
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
                Inventory.Instance.SwitchActiveItem(_equipWeaponButtonPressed);
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

        private void PlaceItemWorld()
        {
            Destroy(_equippedItemWorld.gameObject);
            _equippedItemWorld = Inventory.Instance.GetActiveItem().PlaceItem(weaponHolder);
        }
    }
}
