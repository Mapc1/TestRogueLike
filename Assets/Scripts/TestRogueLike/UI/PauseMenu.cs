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
                IsOpen = pauseMenu.activeSelf;
                Instance = this;
            }
        }
        #endregion

        [SerializeField] private GameObject pauseMenu;

        public bool IsOpen;

        private void Update()
        {
            if (Input.GetButtonDown("Pause") && !InventoryUI.Instance.IsInventoryOpen)
                IsOpen = !IsOpen;

            pauseMenu.SetActive(IsOpen);
            Time.timeScale = pauseMenu.activeSelf ?
                0 : 1;
        }
    }
}
