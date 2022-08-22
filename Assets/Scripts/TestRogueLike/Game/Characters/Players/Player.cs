using TestRogueLike.Game.Items;

namespace TestRogueLike.Game.Characters.Players
{
    public class Player : Character
    {
        public Inventory _inventory { get; private set; }
        
        public Player(int maxHP, Item startingItem) : base(maxHP)
        {
            _inventory = new Inventory(startingItem);
        }
    }
}