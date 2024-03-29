using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehavior : MonoBehaviour {
	private float speed = 40;
	public Color color;
	private string colorString;
	bool hitOrMiss = false;
	// Use this for initialization
	void Start () {
	}

	public void setColor(Color eColor, string cString) {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = eColor;
		colorString = cString;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0, 0);
		if (transform.position.x < -70.0) {
			if (!hitOrMiss) {
				ScoreController.changeTotal ();
				hitOrMiss = true;
				Debug.Log ("hitOrMissTriggered");
			}
		}
		if (transform.position.x < -120 || transform.position.x > 200) {
			Destroy (gameObject);
		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!hitOrMiss) {
			SpriteRenderer sr = GetComponent<SpriteRenderer> ();
			speed = speed * -1;
			string note = "";
			if (Input.GetAxis ("Fire1") > .1) {
				note = "0";
				//Debug.Log ("Red");
			}
			if (Input.GetAxis ("Fire2") > .1) {
				note += "1";
				//Debug.Log("Green");
			}
			if (Input.GetAxis ("Fire3") > .1) {
				note += "2";
				//Debug.Log("Blue");
			}
			if (note == colorString) {
				ScoreController.changeScore ();
				sr.color = new Color (sr.color.r + .3f, sr.color.g + .3f, sr.color.b + .3f, 1);
			} else {
				sr.color = new Color (0, 0, 0, 1);
			}
			ScoreController.changeTotal ();
			hitOrMiss = true;
		}
	}
}
