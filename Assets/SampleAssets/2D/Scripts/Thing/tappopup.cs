using UnityEngine;
using System.Collections;

public class tappopup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("GOT ITEM~1~!!");
        }
	}

    void OnMouseUp()
    {
        Debug.Log("GOT ITEM~~!!");
    }
}
