using TestRogueLike.Game.Items;

namespace TestRogueLike.Game.Characters.Players
{
    public class Player : Character
    {
        public static Player Instance;
        public Inventory Inventory { get; private set; }
        
        public Player(int maxHP, Item startingItem) : base(maxHP)
        {
            Inventory = new Inventory(startingItem);
            Instance = this;
        }
    }
}