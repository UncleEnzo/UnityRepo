﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject projectile; //This Game object is Shot Fired
	public float speed;
	public float padding = 1f;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;
	public AudioClip firesound;
	
	float xmin;
	float xmax;
		
	void Start () {
		Cameraboundaries();
	}
	
	void Cameraboundaries () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distance));
		xmin = leftmost.x + padding;
		xmax = rightmost.x - padding;
	}
	
	void Fire(){
		if (Input.GetKey(KeyCode.Space)) {
			GameObject PewPew = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			PewPew.rigidbody2D.velocity = new Vector3(0, projectileSpeed);
			AudioSource.PlayClipAtPoint(firesound,transform.position);
		}
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating ("Fire",0.000001f, firingRate);	
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("Fire");
		}
	
		if(Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * Time.deltaTime * speed;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			transform.position += Vector3.right * Time.deltaTime * speed;
		}
		//restrict player to gamespace
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die();
			}
		}
	}
	
	void Die(){
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Win Screen");
		Destroy(gameObject);
	}
}
