using UnityEngine;
using System.Collections;

public class Lives : MonoBehaviour {

	public static int PlayerLives = 3;
	public GameObject LifeHeart;
	public GameObject LifeHeart1;
		
	//TODO Destroy one Life sprite Each time player hits losecollider
	//TODO If player restart game, reset player lives and life hearts
	
	void Start () {
		LifeHeart = GameObject.Find("LifeHeart");
		LifeHeart1 = GameObject.Find("LifeHeart1");
		if (Application.loadedLevel == 0) {
				PlayerLives = 3;
			}
		if (PlayerLives == 2) {
			Debug.Log ("GameObject destroyed");
			Destroy(LifeHeart);
		}
		if (PlayerLives == 1) {
			Destroy(LifeHeart);
			Destroy(LifeHeart1);
		}
	}
}