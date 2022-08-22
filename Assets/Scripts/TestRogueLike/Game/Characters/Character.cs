namespace TestRogueLike.Game.Characters
{
    public abstract class Character
    {
        private readonly int maxHP;
        private int curHP;

        protected Character(int maxHP)
        {
            this.maxHP = maxHP;
            curHP = maxHP;
        }
    }
}