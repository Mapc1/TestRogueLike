namespace TestRogueLike.Exceptions.Characters.Players
{
    public class IndexGreaterThanHotbarSize : System.Exception
    {
        public IndexGreaterThanHotbarSize(int index, int hotbarSize) 
            : base($"Index {index} is larger than the hotbar size ({hotbarSize})") {}
    }
}