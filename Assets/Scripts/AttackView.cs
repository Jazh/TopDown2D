using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace TopDown {
    public class AttackView : MonoBehaviour
    {

        public AttackModel model;

        public void Awake()
        {
            model = GetComponent<AttackModel>();
        }

        public void Start()
        {
            //model = GetComponent<AttackModel>();
            UpdateIcon(model.currentAttack);
        }

        public void UpdateIcon(int type) {

            ElementType t = (ElementType) type;
            model.icon.sprite = model.sprites[t];
        
        }
}
}