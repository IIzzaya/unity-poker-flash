using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour {

	private Card[] cards;

	public bool play = false;
	public bool pause = false;
	public bool replay = false;

	// public bool isTotalHide = false;

	public float globalDelay = 0.5f;
	public float globalTimeCost = 2f;
	public float globalTimeStay = 1f;

	public float fromDirection = 180f;
	public float toDirection = -45f;

	private float screenWidth;
	private float screenHeight;
	private float screenDiagonal;
	public float screenBorder = 300f;
	private Vector2 middleScreenPoint;
	[HideInInspector]
	public Vector2 startVector;
	[HideInInspector]
	public Vector2 endVector;

	[HideInInspector]
	public float timer = 0f;

	Vector2 Angle2NormalVector2(float angle) {
		return new Vector2(Mathf.Cos(angle * Mathf.PI / 180), Mathf.Sin(angle * Mathf.PI / 180));
	}

	void CalculateStartEndVector() {
		startVector = (screenDiagonal + screenBorder) * Angle2NormalVector2(fromDirection);
		endVector = (screenDiagonal + screenBorder) * Angle2NormalVector2(toDirection);
		Debug.Log(startVector);
		Debug.Log(endVector);
	}

	void Awake() {
		screenWidth = Screen.width;
		screenHeight = Screen.height;
		Debug.Log("ScreenWidth: " + screenWidth + ", ScreenHeight: " + screenHeight);
		middleScreenPoint = new Vector2(screenWidth, screenHeight);
		screenDiagonal = Mathf.Sqrt(screenHeight * screenHeight + screenWidth * screenWidth);

		cards = gameObject.GetComponentsInChildren<Card>();
		foreach (var card in cards) card.controller = this;

		CalculateStartEndVector();
	}

	// Update is called once per frame
	void Update() {
		if (replay) {
			play = true;
			pause = false;
			replay = false;
			timer = 0;
		}
		if (play && !pause) {
			timer += Time.deltaTime;

			if (timer >= globalDelay + globalTimeCost * 2 + globalTimeStay) {
				play = false;
				timer = 0;
			}

			Debug.Log(timer);
		}
	}
}