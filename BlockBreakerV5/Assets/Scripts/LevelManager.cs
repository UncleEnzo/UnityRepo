﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	//TODO GET THIS TO WORK, When it wakes up, checks scene level name and if it's NOT WinScreen, LoseScreen, or StartMenu then it makes the mouse invisible
	//public void Awake (){
	//	if (Application.loadedLevelName != LoadLevel(string name); ) {
//		    Screen.showCursor = false;
//		}
			
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