namespace TestRogueLike.Game.Characters
{
    public abstract class Character
    {
        public readonly int MaxHP;
        public int CurHP { get; protected set; }
        
        protected Character(int maxHP)
        {
            MaxHP = maxHP;
            CurHP = maxHP;
        }
    }
}