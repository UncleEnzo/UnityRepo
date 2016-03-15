using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	public float health = 150;
	public GameObject Projectile;
	public float projectileSpeed;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	public AudioClip fire;
	public AudioClip death;

	private ScoreKeeper scoreKeeper;
	
	void Start () {
		scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
	}
	
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile) {
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0) {
				Die ();
			}
		}
	}
	
	void Die () {
		Destroy (gameObject);
		scoreKeeper.Score(scoreValue);
		AudioSource.PlayClipAtPoint(death, transform.position);
	}
		
	void Fire () {
			GameObject PewPew = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
			PewPew.rigidbody2D.velocity = new Vector3(0, -projectileSpeed);
			AudioSource.PlayClipAtPoint(fire, transform.position);
	}
	
	void Update () {
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire();
		}
	}
}
