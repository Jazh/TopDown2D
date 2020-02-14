using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class Attack : MonoBehaviour
    {

        public GameObject fire;
        public GameObject ice;
        public int currentAttack;
        [System.Serializable]
        public struct Attacks
        {
            public ElementType type;
            public Projectile prefab;
        }

        public Attacks[] attacksArray;

        public Dictionary<ElementType, Projectile> attacks;
        // Start is called before the first frame update
        void Start()
        {
            attacks = new Dictionary<ElementType, Projectile>();

            foreach (Attacks a in attacksArray)
            {
                attacks.Add(a.type, a.prefab);
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            Shoot(ElementType.fire);
            if (Input.GetKeyDown(KeyCode.Alpha2))
            Shoot(ElementType.ice);

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                currentAttack--;
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                currentAttack++;
            }

            currentAttack = Mathf.Clamp(currentAttack, 0, attacks.Count - 1);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(currentAttack);
            }
        }

        public void Shoot(int type)
        {
            ElementType t = (ElementType)type;
            Shoot(t);
        }

        public void Shoot(ElementType type)
        {
            Instantiate(attacks[type], transform.position, Quaternion.identity);
        }
    }
}