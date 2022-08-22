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
        private static readonly GameObject _mesh = ItemAssets.Instance.assaultRifleModel;
        
        public AssaultRifle() 
            : base(NAME, _mesh, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}