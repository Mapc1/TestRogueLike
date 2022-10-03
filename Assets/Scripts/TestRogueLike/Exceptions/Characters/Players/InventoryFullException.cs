using TestRogueLike.Game.Items;

namespace TestRogueLike.Exceptions.Characters.Players
{
    public class InventoryFullException : System.Exception
    {
        public InventoryFullException(Item item) 
            : base($"Could not add item {item.name} due to a full inventory") {}
    }
}