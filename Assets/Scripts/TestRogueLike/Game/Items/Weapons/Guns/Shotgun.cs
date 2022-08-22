using TestRogueLike.World.Items;
using UnityEngine;

namespace TestRogueLike.Game.Items.Weapons.Guns
{
    public class Shotgun : Gun
    {
        private const string NAME = "Shotgun";
        private const int DAMAGE = 5;
        private const float COOLDOWN = 1.0f;
        private const int MAGSIZE = 6;
        private const BulletType BULLET = BulletType.Slug;
        private static readonly GameObject _mesh = ItemAssets.Instance.pistolModel;
        
        public Shotgun() 
            : base(NAME, _mesh, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}