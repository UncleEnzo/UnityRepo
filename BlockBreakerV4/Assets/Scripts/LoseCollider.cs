using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	private Lives lives;
		
	void OnTriggerEnter2D (Collider2D trigger) {
		Lives.PlayerLives --;
		if (Lives.PlayerLives <= 0) {
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel ("LoseScreen");
		}
		else {
			Application.LoadLevel(Application.loadedLevel);
			Brick.breakableCount = 0;
		}
	}
}