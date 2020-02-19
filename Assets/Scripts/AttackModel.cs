using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopDown
{
    public class AttackModel : MonoBehaviour
    {
        private AttackView view;
        public Image icon;
        //public int currentAttack;
        [System.Serializable]
        public struct Attacks
        {
            public ElementType type;
            public Projectile prefab;
            public Sprite sprite;
        }

        public Attacks[] attacksArray;
        public Dictionary<ElementType, Projectile> attacks;
        public Dictionary<ElementType, Sprite> sprites;


       // public AttackView view;
        private int _currentAttack;
        public int currentAttack {
            get {
                return _currentAttack;
            }
            set {//Clamp limita un valor
                //currentAttack = Mathf.Clamp(currentAttack, 0, attacks.Count - 1);
                _currentAttack = Mathf.Clamp(value, 0, attacks.Count - 1);
                view.UpdateIcon(_currentAttack);
            }
        }
        //Awake se inicializa antes del start
        public void Awake()
        {
            view = GetComponent<AttackView>();
        }

        void Start()
        {
            //view = GetComponent<AttackView>();
            attacks = new Dictionary<ElementType, Projectile>();

            foreach (Attacks a in attacksArray)
            {
                attacks.Add(a.type, a.prefab);
            }

            sprites = new Dictionary<ElementType, Sprite>();

            foreach (Attacks a in attacksArray)
            {
                sprites.Add(a.type, a.sprite);
            }

            currentAttack = 0;
        }


    }



}