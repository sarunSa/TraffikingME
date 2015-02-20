using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {

	// Use this for initialization
    public bool isinSideBox;
    public GameObject popup;
	void Start () {
        popup.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
	}
    void OnTriggerStay2D(Collider2D enter){
        
    }

    void OnTriggerEnter2D(Collider2D enter)
    {
        if (enter.tag == "Player")
        {

            Debug.Log("u nai box na ja");
            isinSideBox = true;
            popup.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.tag == "Player")
        {
            Debug.Log("out box la");
            isinSideBox = false;
            popup.SetActive(false);
        }
        
    }
}


