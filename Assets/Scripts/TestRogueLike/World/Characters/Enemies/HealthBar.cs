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

        [SerializeField] private EnemyWorld enemyWorld;

        private int _curHP;
        private int _maxHP;
        private float _curFill;
        private float _intendedFill;


        private void Start()
        {
            _intendedFill = 1;
            _curFill = 1;
            _maxHP = enemyWorld._enemy.MaxHP;
            _curHP = enemyWorld._enemy.CurHP;
            enemyWorld._enemy.OnHPChangedCallback += UpdateHP;
        }

        private void Update()
        {
            if (!(Math.Abs(_curFill - _intendedFill) > 0.000005)) 
                return;
            
            _curFill -= tweenSpeed;
            if (_curFill < _intendedFill)
                _curFill = _intendedFill;
                
            tween.fillAmount = _curFill;

        }

        private void UpdateHP()
        {
            _curHP = enemyWorld._enemy.CurHP;

            _intendedFill = (float) _curHP / _maxHP;
            foreground.fillAmount = _intendedFill;
        }
    }
}
