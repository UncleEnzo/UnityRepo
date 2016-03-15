using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX;
	public float maxX;
	
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay == false) {
		MoveWithMouse ();
		}
		else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16; //Mouse measurement = Relative mouse position to screen width multiplied by total game units
		
		Vector3 paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, minX, maxX), this.transform.position.y, 0f);
		
		this.transform.position = paddlePos;
		}
	
	//Mouse move to Y position of the ball
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0.5f); //sets paddle position to be its Y coorindate in the game
		Vector3 ballPos = ball.transform.position; //Declares ballPos to be the ball's position to be its transform
		this.transform.position = paddlePos;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
	}
}
