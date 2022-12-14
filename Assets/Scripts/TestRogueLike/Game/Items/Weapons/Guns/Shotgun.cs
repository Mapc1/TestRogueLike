using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons.Guns
{
    public class Shotgun : Gun
    {
        private const string NAME = "Shotgun";
        private const int DAMAGE = 2;
        private const float COOLDOWN = 1.0f;
        private const int MAGSIZE = 6;
        private const BulletType BULLET = BulletType.Slug;
        private static readonly GameObject MESH = ItemAssets.Instance.shotgunModel;
        private static readonly Sprite ICON = ItemAssets.Instance.shotgunIcon;
        
        public Shotgun() 
            : base(NAME, MESH, ICON, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}