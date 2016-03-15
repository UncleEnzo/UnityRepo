using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	void Awake () {
		GameObject musicManager = GameObject.Find("Persistent Music");
		if (musicManager) {
			musicManager.audio.volume = PlayerPrefsManager.GetMasterVolume();
		}
		else {
			Debug.LogWarning ("No music manager found.");
		}
	}
}