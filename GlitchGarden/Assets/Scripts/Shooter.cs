﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject projectileParent;
	public GameObject gun;
	
	private void Fire () {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		Debug.Log(newProjectile.transform.position);
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}