using UnityEngine;

namespace TestRogueLike.UI.Menus
{
    public class SettingsCard : MenuCard
    {
        [SerializeField] private GameObject settingsPanel;
        
        public override void Select()
        {
            PauseMenu.Instance.PushState(settingsPanel);
        }
    }
}
