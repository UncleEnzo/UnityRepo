using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {	
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	void OnCollisionEnter2D(Collision2D col){
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		if (hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
		
	// Update is called once per frame
	void Update () {
	if (!hasStarted){
			//lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector; // sets original ball to stick to paddle
			
			//waiting for ball to launch
			if (Input.GetMouseButtonDown(0)) {
				this.rigidbody2D.velocity = new Vector2(2f, 10f); //Giving ball velocity
				hasStarted = true;
			}
		}
	}
}