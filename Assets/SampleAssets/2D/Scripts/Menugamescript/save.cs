using UnityEngine;
using System.Collections;

public class save : MonoBehaviour {

	// Use this for initialization
    clickCounter name1;
	void Start () {
        name1 = GameObject.FindGameObjectWithTag("savebutton").GetComponent<clickCounter>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void saveCount ()
    {
        //int saveNum = num;

        PlayerPrefs.SetInt("saveNum", name1.count);

        Debug.Log("Savedd");
    }
}
