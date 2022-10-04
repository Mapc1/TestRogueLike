using UnityEngine.Device;

namespace TestRogueLike.UI.Menus
{
    public class QuitCard : MenuCard
    {
        public override void Select()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}