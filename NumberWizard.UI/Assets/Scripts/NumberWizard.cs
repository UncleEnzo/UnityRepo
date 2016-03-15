using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;
	int guess;
	public int maxGuessesAllowed = 10;
	
	public Text text;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame () {
		max = 1001;
		min = 1;
		guess = 500;
		NextGuess();
		
	}
	
	void NextGuess () {
		guess = Random.Range(min, max+1);
		text.text = guess.ToString();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if (maxGuessesAllowed<=0){
			Application.LoadLevel("Win");
		}
	}
	
	public void guessHigher (){
		min = guess;
		NextGuess ();
	}
	
	public void guessLower (){
		max = guess;
		NextGuess ();
	}
}
