using UnityEngine;
using System.Collections;

public class drawLine : MonoBehaviour {

    private LineRenderer lineRenderer;
    private float counter;
    private float counter2;
    private float dist;

    public Transform origin;
    public Transform destination;
    public float lineDrawSpeed = 6f;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        //lineRenderer.SetWidth(.45f, .45f);

        dist = Vector3.Distance(origin.position, destination.position);
	}
	
	// Update is called once per frame
	void Update () {
	    if(counter < dist)
        {
            Debug.Log("Counter: " + counter);
            Debug.Log("Dist: " + dist);
            counter += .1f / lineDrawSpeed;

            float x = Mathf.Lerp(0, dist, counter);

            Debug.Log("X: " + x);

            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);

            if (x >= dist/2)
            {
                counter2 += .1f / lineDrawSpeed;
                float y = Mathf.Lerp(0, dist, counter2);
                Vector3 trail = y * Vector3.Normalize(pointB - pointA) + pointA;
                lineRenderer.SetPosition(0, trail);
            }
        }
	}
}
