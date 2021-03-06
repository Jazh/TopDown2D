﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown { 
public class Talk : MonoBehaviour
{

    private GameObject npc = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (npc != null) {
                    DialogController.Show(0);
            }
        }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (npc != null)
                    DialogController.Next();
            }

        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC") {
            npc = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npc = null;
        }
    }
}
}