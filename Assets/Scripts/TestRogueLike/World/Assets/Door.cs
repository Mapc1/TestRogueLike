using System;
using TestRogueLike.Common;
using TestRogueLike.World.Characters.Players;
using UnityEngine;

namespace TestRogueLike.World.Assets
{
    public class Door : MonoBehaviour, Interactable
    {
        private float cur_pos;
        private float intended_pos;
        private readonly float speed = 0.05f;

        private void Start()
        {
            cur_pos = gameObject.transform.position.y;
            intended_pos = cur_pos;
        }

        private void Update()
        {
            if (!(Math.Abs(cur_pos - intended_pos) > 0.001))
                return;
            
            if (Math.Abs(intended_pos - 1) < 0.001)
                cur_pos += speed;
            else
                cur_pos -= speed;

            if (Math.Abs(cur_pos) - Math.Abs(intended_pos) > 0)
                cur_pos = intended_pos;

            var objPos = gameObject.transform.position;
            gameObject.transform.position = new Vector3(objPos.x, cur_pos, objPos.z);
        }

        public void Interact(PlayerWorld player)
        {
            if (Math.Abs(intended_pos - 1) < 0.001)
                intended_pos = -1;
            else
                intended_pos = 1;
        }
    }
}