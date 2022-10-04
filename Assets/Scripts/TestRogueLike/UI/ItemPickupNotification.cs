using System;
using TestRogueLike.Game.Characters.Players;
using TestRogueLike.Game.Items;
using TMPro;
using UnityEngine;

namespace TestRogueLike.UI
{
    public class ItemPickupNotification : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float uptime;
        [SerializeField] private float fadeTime;

        private CanvasGroup _canvas;
        
        private float _fadeStartTime;

        private void Start()
        {
            Player.Instance.Inventory.OnItemPickupCallback += Show;
            _canvas = GetComponent<CanvasGroup>();
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            var time = Time.time;
            if (time < _fadeStartTime)
                return;
            
            var alpha = 1 - ((time - _fadeStartTime) / fadeTime);

            if (alpha <= 0)
                gameObject.SetActive(false);
            else 
                _canvas.alpha = alpha;
        }

        private void Show(Item item)
        {
            text.SetText($"Congratulations! You just got a {item.name}");
            _canvas.alpha = 1.0f;
            gameObject.SetActive(true);
            _fadeStartTime = Time.time + uptime;
        }
    }
}