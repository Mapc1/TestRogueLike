using UnityEngine;

namespace TestRogueLike.World.Items.Weapons.Guns
{
    public class PistolWorld : GunWorld
    {
        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _audioSource = GetComponent<AudioSource>();
        }
    }
}