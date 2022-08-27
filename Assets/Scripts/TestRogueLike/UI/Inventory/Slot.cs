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

            public int SlotNum;
        #endregion

        private void Start()
        {
            _itemCursor = Interface.Instance.ItemCursor;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        #region DraggableMethods

            public virtual void OnDrop(PointerEventData eventData)
                => Debug.Log("OnDrop");

            public void OnPointerDown(PointerEventData eventData)
            {
                if (Item != null) 
                    _canvasGroup.alpha = 0.6f;
            }

            public void OnPointerUp(PointerEventData eventData)
                => _canvasGroup.alpha = 1.0f;

            public void OnBeginDrag(PointerEventData eventData)
            {
                if (Item == null)
                    return;
                
                _itemCursor.GetComponent<Image>().sprite = Item.icon;
                _itemCursor.transform.position = Input.mousePosition;
                _itemCursor.gameObject.SetActive(true);
                _canvasGroup.blocksRaycasts = false;
                icon.enabled = false;
            }

            public void OnEndDrag(PointerEventData eventData)
            {
                _itemCursor.gameObject.SetActive(false);
                _canvasGroup.blocksRaycasts = true;
                icon.enabled = Item != null;
            }

            public void OnDrag(PointerEventData eventData)
                => _itemCursor.transform.position = Input.mousePosition;
        #endregion

        #region SlotMethods
            public virtual void AddItem(Item item)
            {
                if (item == null)
                    return;
                
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
    }
}