using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	private float currentSpeed = 0;
	private GameObject currentTarget;
	public Health health;
	private Animator animator;
	

	void Start () {
		animator = GetComponent<Animator>();
		health = GetComponent<Health>();
	}
	
	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("IsAttacking", false);
		}
	}
	
	void OnTriggerEnter2D (Collider2D collider) {

	}
	
	public void SetSpeed (float speed) {
		currentSpeed = speed;
	}
	
	public void StrikeCurrentTarget(float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
		
	}
}
