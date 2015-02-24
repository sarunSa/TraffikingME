using UnityEngine;
using System.Collections;

public class tapHelp : MonoBehaviour {

	// Use this for initialization
    public bool helpStatus;
    GameObject victim;
	void Start () {
        victim = GameObject.FindGameObjectWithTag("Victim");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            helpStatus = true;
            victim.collider2D.isTrigger = false;
            victim.rigidbody2D.gravityScale = 30;
        }
	}
}
