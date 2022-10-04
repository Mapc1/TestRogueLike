using System.Collections.Generic;
using UnityEngine;

namespace TestRogueLike.UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region Singleton
        public static PauseMenu Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else {
                isOpen = pauseMenu.activeSelf;
                Instance = this;
            }
        }
        #endregion

        [SerializeField] private GameObject pauseMenu;

        public bool isOpen;
        private readonly Stack<GameObject> _stateStack = new();

        private void LateUpdate()
        {
            if (!Input.GetButtonDown("Pause") || InventoryUI.Instance.IsInventoryOpen)
                return;
            
            if (isOpen)
                PopState();
            else
                PushState(pauseMenu);
        }

        public void PushState(GameObject obj)
        {
            if (_stateStack.Count != 0)
            {
                var top = _stateStack.Peek();
                top.SetActive(false);
            }

            isOpen = true;
            Time.timeScale = 0;
            _stateStack.Push(obj);
            obj.SetActive(true);
        }

        public void PopState()
        {
            var top = _stateStack.Pop();
            top.SetActive(false);
            if (_stateStack.Count == 0)
            {
                isOpen = false;
                Time.timeScale = 1;
                return;
            }
            
            var newTop = _stateStack.Peek();
            newTop.SetActive(true);
        }
    }
}
