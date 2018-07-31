using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	[HideInInspector]
	public FlashController controller;

	// public bool useGlobalSettings = true;

	public float relativeDelay = 0;
	public float relativeTimeCost = 0;
	public float relativeTimeStay = 0;

	private Vector2 originalPosition;

	void Awake() {
		originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update() {
		if (controller.play) {
			var timer = controller.timer;
			timer -= controller.globalDelay + relativeDelay;
			if (timer < 0) return;
			else timer -= controller.globalTimeCost + relativeTimeCost;

			if (timer < 0) {
				transform.position = originalPosition + (-timer) / (controller.globalTimeCost + relativeTimeCost) * controller.startVector;
				return;
			} else timer -= controller.globalTimeStay + relativeTimeStay;

			if (timer < 0) {
				transform.position = originalPosition;
				return;
			}
			else timer -= controller.globalTimeCost + relativeTimeCost;

			if (timer < 0) {
				transform.position = originalPosition + (1 - (-timer) / (controller.globalTimeCost + relativeTimeCost)) * controller.endVector;
				return;
			}
		}
	}
}