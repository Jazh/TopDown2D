using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{

    public Vector2[] points;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos() {
        Vector3 point = points[0];
        //Debug.DrawLine(transform.position, points[0], Color.cyan, 0.1f);
        Debug.DrawLine(transform.position, transform.position + point, Color.cyan, 0.1f);
        for (int i = 1; i < points.Length ; i++) {
            //Debug.DrawLine
            point = points[i-1];
            Vector3 start = transform.position + point;
            point = points[i];
            Vector3 end = start + point;

            Debug.DrawLine(start, end, Color.cyan);

        }
        point = points[points.Length - 1];
        Debug.DrawLine(transform.position + point, transform.position, Color.cyan);

    }

}
