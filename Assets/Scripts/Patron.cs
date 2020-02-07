using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDown.AI
{
    public class Patron : MonoBehaviour
    {
        int currentIndex;
        float t = 0f;
        Vector3 startPos;
        Vector3 endPos;
        private List<Vector3> points;
 
       // Vector3 point;
      //  Vector3 origin;
      //  public Vector2[] points;
        public ActionArea player;
        public float speed = 1f;

        public Path path;

        // Start is called before the first frame update
        void Start()
        {


            currentIndex = 0;
            //    point = points[currentIndex];
            //  origin = transform.position;
            points = path.points;

            startPos = points[0];
            endPos = points[1];

            if (path.type == PathType.reset && path.isClosed) { 
                points.Add(points[0]);
        }
    }

        // Update is called once per frame
        void Update()
        {
            //Vector3 point = points[0];
            transform.position = Vector3.Lerp(startPos, endPos, t);

            t += Time.deltaTime * speed;
            /*
            if (Vector3.Distance(transform.position, player.transform.position) <= player.radius)
            {
                speed *= 2f;
            }
            else
            {
                float distance = Vector3.Distance(startPos, endPos);
                speed = 2f / distance;
            }*/

            if (t >= 1f)
            {
                currentIndex++;
                /*
                if (currentIndex >= points.Count)
                {
                    currentIndex = -1;
                    point = Vector3.zero;
                }
                else
                {
                    point = points[currentIndex];
                }
                endPos = origin + point;

                if (path.isClosed && currentIndex >= points.Count)
                {
                    currentIndex = 0;
                }

                endPos = points[currentIndex];*/

                if (currentIndex >= points.Count) {
                    OnFinishPath();
                }

                startPos = endPos;
                endPos = points[currentIndex];

                float distance = Vector3.Distance(startPos, endPos);
                speed = 2f / distance;

                t = 0;
            }
        }

        private void OnFinishPath() {
            switch (path.type) {

                case PathType.loop:
                    currentIndex = 0;
                    if (!path.isClosed)
                    {
                        endPos = points[currentIndex];
                        transform.position = endPos;
                    }
                    
                    break;

                case PathType.reset:
                    points.Reverse();
                    currentIndex = 0;
                    break;
                    
            
            }/*
            if (path.isClosed) {
                currentIndex = 0;
            }
            endPos = points[currentIndex];*/
        }


        /*
        private void OnDrawGizmos()
        {
            if (!Application.isPlaying && origin != transform.position)
            {
                origin = transform.position;
            }
            Vector3 point = points[0];
            //Debug.DrawLine(transform.position, points[0], Color.cyan, 0.1f);
            //Debug.DrawLine(transform.position, transform.position + point, Color.cyan, 0.1f);
            Debug.DrawLine(origin, origin + point, Color.cyan, 0.1f);
            for (int i = 1; i < points.Length; i++)
            {
                //Debug.DrawLine
                point = points[i - 1];
                Vector3 start = origin + point;
                point = points[i];
                Vector3 end = origin + point;

                Debug.DrawLine(start, end, Color.cyan);

            }
            point = points[points.Length - 1];
            Debug.DrawLine(origin + point, origin, Color.cyan);

        }*/

    }
}