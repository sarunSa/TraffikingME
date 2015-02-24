using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void changeScene(int i)
    {
        switch (i)
        {
            case 0: Application.LoadLevel("firstPage"); break;
            case 1: Application.LoadLevel("loadPage"); break;
            case 2: Application.LoadLevel("selectCharPage"); break;
            case 3: Application.LoadLevel("creditPage"); break;
            case 4: Application.LoadLevel("start_point"); break;
        }
    }
}
