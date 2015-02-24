using UnityEngine;
using System.Collections;

public class taplocker : MonoBehaviour {

    public bool inLocker;
    public taplocker oppositeTap;
	// Use this for initialization
	void Start () {
        inLocker = false;
        oppositeTap = oppositeTap.GetComponent<taplocker>();

	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inLocker = !inLocker;
            oppositeTap.inLocker = inLocker;

        }
    }
}
