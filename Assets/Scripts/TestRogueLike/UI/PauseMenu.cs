using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    #region Singleton
        public static PauseMenu Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }
    #endregion

    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
            pauseMenu.SetActive(!pauseMenu.activeSelf);

        Time.timeScale = pauseMenu.activeSelf ?
            0 : 1;
    }
}
