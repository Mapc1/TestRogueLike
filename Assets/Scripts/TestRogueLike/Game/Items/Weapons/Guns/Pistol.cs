using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons.Guns
{
    public class Pistol : Gun
    {
        private const string NAME = "Pistol";
        private const int DAMAGE = 1;
        private const float COOLDOWN = 0.4f;
        private const int MAGSIZE = 10;
        private const BulletType BULLET = BulletType.Light;
        private static readonly GameObject MESH = ItemAssets.Instance.pistolModel;
        private static readonly Sprite ICON = ItemAssets.Instance.pistolIcon;

        public Pistol() 
            : base(NAME, MESH, ICON, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}