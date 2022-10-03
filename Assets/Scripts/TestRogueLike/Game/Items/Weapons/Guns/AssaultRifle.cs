using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons.Guns
{
    public class AssaultRifle : Gun
    {
        private const string NAME = "Assault Rifle";
        private const int DAMAGE = 2;
        private const float COOLDOWN = 0.15f;
        private const int MAGSIZE = 30;
        private const BulletType BULLET = BulletType.Medium;
        private static readonly GameObject MESH = ItemAssets.Instance.assaultRifleModel;
        private static readonly Sprite ICON = ItemAssets.Instance.assaultRifleIcon;
        
        public AssaultRifle() 
            : base(NAME, MESH, ICON, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}