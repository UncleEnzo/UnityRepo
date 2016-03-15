using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	
	
	void Start () {
		isBreakable = (this.tag == "Breakable"); //keep track of breakable bricks
		if (isBreakable) {
			breakableCount ++;
		}
		timesHit = 0;
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	void Update () {
	}
	
	void OnCollisionEnter2D(Collision2D col){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}
	
	void HandleHits () {
		timesHit ++;
		int maxHits = hitSprites.Length + 1;
			if(timesHit >= maxHits){
				breakableCount --;
				levelManager.BrickDestroyed();
				PuffSmoke();
				Destroy(gameObject, Time.deltaTime);
			}
			else {
				LoadSprites ();
			}

	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError("Missing Brick sprite.");
		}
	}
			
	//TODO Remove this method once we can actually win
	void SimulateWin () {
		levelManager.LoadNextlevel();
	}
}