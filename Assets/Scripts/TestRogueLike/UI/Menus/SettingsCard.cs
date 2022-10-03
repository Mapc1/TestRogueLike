using UnityEngine;

namespace TestRogueLike.UI.Menus
{
    public class SettingsCard : MenuCard
    {
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private GameObject pauseMenu;
        
        public override void Select()
        {
            settingsPanel.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }
}
