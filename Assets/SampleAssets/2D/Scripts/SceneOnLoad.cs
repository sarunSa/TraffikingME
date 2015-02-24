using UnityEngine;
using System.Collections;

public class SceneOnLoad : MonoBehaviour {

	// Use this for initialization
    public string summon;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {

        GameObject[] temp = GameObject.FindGameObjectsWithTag("summonPoint");
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].name == summon)
            {
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                player.position = temp[i].transform.position;
            }
 

        }
        GameObject[] tempCharacter = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] tempCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        if (tempCharacter.Length > 1 && tempCamera.Length > 1)
        {
            Destroy(tempCharacter[1]);
            Destroy(tempCamera[1]);
        }
    }
}
