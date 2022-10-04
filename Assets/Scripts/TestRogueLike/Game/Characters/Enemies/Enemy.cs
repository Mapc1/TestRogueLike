using TestRogueLike.Game.Items.Weapons;

namespace TestRogueLike.Game.Characters.Enemies
{
    public class Enemy : Character
    {
        private Weapon weapon;

        public delegate void OnDeath();
        public OnDeath OnDeathCallback;

        public delegate void OnHPChanged();
        public OnHPChanged OnHPChangedCallback;

        public Enemy(int maxHP, Weapon weapon) : base(maxHP)
        {
            this.weapon = weapon;
        }

        public void TakeDmg(int dmg)
        {
            CurHP -= dmg;
            
            OnHPChangedCallback.Invoke();
            if (!IsAlive())
                OnDeathCallback.Invoke();
        }

        public bool IsAlive()
        {
            return CurHP > 0;
        }
    }
}