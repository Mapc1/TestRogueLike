using TestRogueLike.Game.Items.Weapons.Guns;

namespace TestRogueLike.Game.Characters.Enemies
{
    public class BasicEnemy : Enemy
    {
        private const int MAXHP = 10;

        public BasicEnemy() : base(MAXHP, new Pistol())
        {}
    }
}