using UnityEngine;
using System.Collections;

public class load : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int myVariable = PlayerPrefs.GetInt("saveNum");

        print(myVariable);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
