using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    public Vector2 minXY;
    public Vector2 maxXY;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 point = camera.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            float targetX = Mathf.Clamp(destination.x, minXY.x, maxXY.x);
            float targetY = Mathf.Clamp(destination.y, minXY.y, maxXY.y);
            destination = new Vector3(targetX, targetY , destination.z);
            
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

        }
	}
}
