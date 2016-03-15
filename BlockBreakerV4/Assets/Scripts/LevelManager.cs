using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {	
	
	public void Awake (){
		Screen.showCursor = false;
		if (Application.loadedLevel == 0) {
			Screen.showCursor = true;		
		}
		if (Application.loadedLevel == 1) {
			Screen.showCursor = true;		
		}
		if (Application.loadedLevel == 2) {
			Screen.showCursor = true;		
		}
	}
				
	public void LoadLevel(string name){
		Application.LoadLevel(name);
		Brick.breakableCount = 0;
	}
	public void QuitRequest(){
		Application.Quit();
	}
	
	public void LoadNextlevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed () {
		if (Brick.breakableCount <= 0){
			LoadNextlevel();
			Brick.breakableCount = 0;
		}
	}
}