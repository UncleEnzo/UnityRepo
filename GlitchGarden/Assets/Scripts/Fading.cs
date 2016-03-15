﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour {
	public float fadeInTime = 1.2f;

	private Image fadePanel;
	private Color currentColor = Color.black;

	void Start () {
		fadePanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		}
		else {
			gameObject.SetActive(false);
		}
	}
}
