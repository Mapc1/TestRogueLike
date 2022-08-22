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
        private static readonly GameObject _mesh = ItemAssets.Instance.pistolModel;

        public Pistol() 
            : base(NAME, _mesh, DAMAGE, COOLDOWN, MAGSIZE, BULLET) {}
    }
}