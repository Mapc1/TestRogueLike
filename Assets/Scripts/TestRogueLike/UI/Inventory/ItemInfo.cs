using System;
using TestRogueLike.Game.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class ItemInfo : MonoBehaviour
    {
        #region Singleton 
        public static ItemInfo Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
            {
                Instance = this;
                gameObject.SetActive(false); // Hide it after awaking
            }
        }
        #endregion

        [SerializeField] private TextMeshProUGUI ItemName;
        [SerializeField] private TextMeshProUGUI ItemStats;
        [SerializeField] private Image ItemIcon;

        private void Update()
            => transform.position = Input.mousePosition;

        public void ShowTooltip(Item item)
        {
            transform.position = Input.mousePosition;
        
            ItemName.SetText(item.name);
            ItemIcon.sprite = item.icon;
            ItemStats.SetText(item.GetStats());
        
            gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }
    }
}
