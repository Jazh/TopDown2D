using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown
{
    public class AttackController : MonoBehaviour
    {
        private AttackModel model;
        // Start is called before the first frame update
        void Start()
        {
            model = GetComponent<AttackModel>();
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
                model.currentAttack--;
            }

            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                model.currentAttack++;
            }

            //model.currentAttack = Mathf.Clamp(model.currentAttack, 0, model.attacks.Count - 1);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot(model.currentAttack);
            }
        }


        public void Shoot(int type)
        {
            ElementType t = (ElementType)type;
            Shoot(t);
        }

        public void Shoot(ElementType type)
        {
            Instantiate(model.attacks[type], transform.position, Quaternion.identity);
        }

    }
}