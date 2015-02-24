using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour {
	
	
	public int levelNr;
	
	
	
	void Start ()
	{
		GetComponent<GUIText>().text += levelNr;
	}
	
	
	
	void OnMouseUp ()
	{
		ApplicationModel.currentLevel = levelNr;
		Application.LoadLevel ("MyGame");
	}

	
}
