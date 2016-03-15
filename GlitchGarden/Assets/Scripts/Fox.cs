﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;
	private float damage = 2;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;
		
		//Abort or leave the method if not colliding with the defender
		if (!obj.GetComponent<Defender>()) {
			return;
		}
		if (obj.GetComponent<Stone>()) {
			anim.SetTrigger ("Fox Jump");
		}
		else {
			anim.SetBool ("IsAttacking", true);
			attacker.Attack (obj);
			attacker.StrikeCurrentTarget (damage);
		}
		Debug.Log ("Fox collided with " + collider);
	}
}
