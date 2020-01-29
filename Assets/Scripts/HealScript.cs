using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealScript : MonoBehaviour
{

    public Image fullHeart;
    public Image[] quarterHeart;
    public Image emptyHeart;

    public int maxLife = 12;
    public int maxHearts {
        get {
            return maxLife / 4;
        }

    }


    public int currentLife = 12;
    public int fullHearts {

        get {
            return currentLife / 4;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts();
    }

    public int quarterHearts {

        get {
            return currentLife % 4 ;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clear() {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        }
    public void UpdateHearts() {
        Clear();
        for(int i = 0; i < fullHearts; i++) {
            Instantiate<Image>(fullHeart, transform);
        }

        if(quarterHearts > 0) {
            Instantiate<Image>(quarterHeart[quarterHearts], transform);
        }

        int currentHearts = fullHearts + (quarterHearts > 0 ? 1 : 0);
        for(int i = 0; maxHearts - currentHearts > i; i++) {
            Instantiate<Image>(emptyHeart, transform);
        }
    }

}
