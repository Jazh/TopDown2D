using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TopDown { 
public class Enemy : MonoBehaviour
{
        public ElementType type = ElementType.fire;
        public ElementType weak = ElementType.fire;

        private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();

            if (projectile != null)
                if (projectile.type == weak)
                    Destroy(gameObject);

        }
}
}