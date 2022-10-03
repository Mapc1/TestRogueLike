using System;
using UnityEngine;
using UnityEngine.UI;

namespace TestRogueLike.World.Characters.Enemies
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private float tweenSpeed;
        [SerializeField] private Image foreground;
        [SerializeField] private Image tween;

        private int _curHP;
        private int _maxHP;
        private float _curFill;
        private float _intendedFill;

        
        void Start()
        {
            _intendedFill = 1;
            _curFill = 1;
        }

        private void Update()
        {
            if (Math.Abs(_curFill - _intendedFill) > 0.000005)
            {
                _curFill -= tweenSpeed;
                if (_curFill < _intendedFill)
                {
                    _curFill = _intendedFill;
                }
                
                tween.fillAmount = _curFill;
            }

        }

        public void UpdateHP(int curHP, int maxHP)
        {
            _curHP = curHP;
            _maxHP = maxHP;

            float newFill = (float) _curHP / _maxHP;
            foreground.fillAmount = newFill;
            _intendedFill = newFill;
        }
    }
}
