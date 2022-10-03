using TestRogueLike.World.Characters.Players;

namespace TestRogueLike.Common
{
    public interface Interactable
    {
        public const int LAYER = 9;
        public void Interact(PlayerWorld player);
    }
}