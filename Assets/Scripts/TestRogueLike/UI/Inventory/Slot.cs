using System;
using TestRogueLike.Game.Items;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TestRogueLike.UI.Inventory
{
    public class Slot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
    {
        #region Vars 
            public Item Item { get; private set; }
            public Image icon;
            
            private RectTransform _itemCursor;
            private CanvasGroup _canvasGroup;
        #endregion

        private void Start()
        {
            _itemCursor = Interface.Instance.ItemCursor;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        #region DraggableMethods 
            public virtual void OnDrop(PointerEventData eventData)
            {
                Debug.Log("OnDrop");
                
                if (eventData.pointerDrag == null)
                    return;

                var item = eventData.pointerDrag.GetComponent<Slot>().Item;
                Game.Characters.Players.Inventory.Instance.SwapItems(Item, item);
            }

            public void OnPointerDown(PointerEventData eventData)
            {
                _canvasGroup.alpha = 0.6f;
            }

            public void OnBeginDrag(PointerEventData eventData)
            {
                _itemCursor.GetComponent<Image>().sprite = Item.icon;
                _itemCursor.transform.position = Input.mousePosition;
                _itemCursor.gameObject.SetActive(true);
                _canvasGroup.blocksRaycasts = false;
                icon.enabled = false;
            }

            public void OnEndDrag(PointerEventData eventData)
            {
                _itemCursor.gameObject.SetActive(false);
                icon.enabled = true;
                _canvasGroup.blocksRaycasts = true;
            }

            public void OnDrag(PointerEventData eventData)
            {
                _itemCursor.transform.position = Input.mousePosition;
            }
        #endregion

        #region SlotMethods
            public virtual void AddItem(Item item)
            {
                Item = item;
                icon.sprite = Item.icon;
                icon.enabled = true;
            }

            public virtual void ClearSlot()
            {
                Item = null;
                icon.sprite = null;
                icon.enabled = false;
            }
        #endregion

        public void OnPointerUp(PointerEventData eventData)
        {
            _canvasGroup.alpha = 1.0f;
        }
    }
}