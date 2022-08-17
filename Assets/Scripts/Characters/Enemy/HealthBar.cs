using UnityEngine;
using UnityEngine.UI;

namespace Characters.Enemy
{
    public class HealthBar : MonoBehaviour
    {
        private int _curHp;
        private int _maxHp;

        private Image _image;
        
        void Start()
        {
            _image = GetComponent<Image>();
        }

        public void UpdateHP(int curHP, int maxHP)
        {
            _curHp = curHP;
            _maxHp = maxHP;

            _image.fillAmount = (float) _curHp / _maxHp;
        }
    }
}
