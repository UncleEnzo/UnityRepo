using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text;
	private enum States {options0, selfExamine, openDoor, recallDeadMan, options1, win};
	private States myState;

	void Start () {
		myState = States.options0;
	}

	void Update () {
		if (myState == States.options0) {
			state_cell();
		}
		else if (myState == States.selfExamine) {
			self_examine();
		}
		else if (myState == States.openDoor) {
			keyopen_door();
		}
		else if (myState == States.recallDeadMan) {
			recall_deadman();
		}
		else if (myState == States.win) {
			you_win();
		}
	}	

	#region State handler methods

	void state_cell () {
		text.text = ("A man looks at you through the bars." +
		             " He reminds you that you can try to leave and might even succeed." +
		             " He then smirks and waggles a finger at you, explaining that if you fail " +
		             "your life will become a living hell.  He'll snip off your fingers by the knuckles and pluck out your eyes." +
		             " The man chuckles as you cower away from him and prepares to depart." +
		             " Just before he exits, he takes a moment to light a cigarette and makes a show of producing a key and dropping" + 
		             " it on the floor before walking out of your cell and locking the door from the outside.\n\n" +
		             " You crawl over to the key and pick it up."  +
			         " The key is a rustic brass color and still warm to the touch.\n\n" +
			         "Press Q to examine yourself.\n\n" +
			         "Press W to use the key and open the door.\n\n" +
			         "Press E to recall what the dead man said.");
		if (Input.GetKeyDown(KeyCode.Q)) {
			myState = States.selfExamine;
		}
		else if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.openDoor;
		}
		else if (Input.GetKeyDown(KeyCode.E)) {
			myState = States.recallDeadMan;
		}
	}
	
	void self_examine () {
		text.text = ("You are naked.  Your arms and legs are scraped up and you have a bad cough." +
		             " You wheeze with each breath and you can see your breath on the frigid air." +
		             " You will not last long in a cell like this, although you recall hearing" +
		             " that freezing to death is a peaceful way to go.\n\n" +
		             " Press R to steel yourself to the task at hand.");
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.options0;
		}
	}
	
	void keyopen_door () {
		text.text = ("You insert the cooling key into the door's locking mechanism and turn it." +
		             " The lock is reluctant at first, but it gives way with a satisfying click.\n\n" +
		             "Freedom, or atleast you hope so.\n\n" +
		             "Who knows what can be waiting on the otherside.  Perhaps the man is waiting there with his pliers. Perhaps not." +
		             " You suck in a breath and push the door open.\n\n" +
		             "Press Space to walk through the door.");
		if (Input.GetKeyDown(KeyCode.Space)){
			myState = States.win;
		}		
	}
	
	void recall_deadman () {
		text.text = ("There was a man once that told you to put aside pain and death." +
		             "  He called them petty things and urged you to push forward regardless of your fears." +
		             "  That man is dead now.  Only his words remain with you.\n\n" +
		             "Press R to collect your thoughts and prepare for what you have to do.");
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.options0;
		}
	}
	
	void you_win () {
		text.text = ("You walk through the door and realize there's just DICKS everywhere." +
					 "You breathe a sigh of relief.  This you can deal with." +
		             "You casually stroll past the penises and out the into the world.\n\n" +
		             "Press Space to play again... I mean like if you actually wanna do the same shit a second time.");
		if (Input.GetKeyDown(KeyCode.Space)){
			myState = States.options0;
		}		
	}
	
	#endregion
}
