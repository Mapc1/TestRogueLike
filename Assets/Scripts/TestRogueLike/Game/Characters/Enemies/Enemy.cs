using TestRogueLike.Game.Items.Weapons;

namespace TestRogueLike.Game.Characters.Enemies
{
    public abstract class Enemy : Character
    {
        private Weapon weapon;

        protected Enemy(int maxHP, Weapon weapon) : base(maxHP)
        {
            this.weapon = weapon;
        }
    }
}