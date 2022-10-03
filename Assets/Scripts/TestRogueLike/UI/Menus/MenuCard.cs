using UnityEngine;
using UnityEngine.EventSystems;

namespace TestRogueLike.UI.Menus
{
    public abstract class MenuCard : MonoBehaviour, IPointerClickHandler
    {
        public abstract void Select();
        public void OnPointerClick(PointerEventData eventData)
        {
            Select();
        }
    }
}