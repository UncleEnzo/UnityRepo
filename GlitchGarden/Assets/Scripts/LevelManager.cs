using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoloadNextLevelAfter = 3f;
	public bool fadeoutAlpha = false;

	void Start () {
		if (autoloadNextLevelAfter <= 0) {
			Debug.Log ("AutoLoad disabled.");
		}
		else{
			Invoke ("LoadNextLevel", autoloadNextLevelAfter);
		}
	}

//Add an Invoke to this
	public void LoadLevel(string name){
		Application.LoadLevel (name);
		fadeoutAlpha = true;
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
		fadeoutAlpha = true;
	}
}
