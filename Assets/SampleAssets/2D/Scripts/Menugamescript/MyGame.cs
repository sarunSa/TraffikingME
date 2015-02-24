using UnityEngine;
using System.Collections;

public class MyGame : MonoBehaviour {
	
	
	
	void Start ()
	{
		int levelNr = ApplicationModel.currentLevel;
		loadLevelData (levelNr);
	}
	
	

	void loadLevelData (int nr)
	{
		// load level data here
		
		GameObject.Find("Message").GetComponent<GUIText>().text += nr;
	}

	
}
