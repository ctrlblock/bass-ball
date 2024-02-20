using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteBehavior : MonoBehaviour {
	private float speed = 40;
	private string colorString;
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
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		speed = speed * -1;
		string note = "";
		if (Input.GetAxis ("Fire1") > .1) {
			note = "Red";
			//Debug.Log ("Red");
		}
		if (Input.GetAxis ("Fire2") > .1) {
			note = "Green";
			//Debug.Log("Green");
		}
		if (Input.GetAxis ("Fire3") > .1) {
			note = "Blue";
			//Debug.Log("Blue");
		}
		if (note.Equals (colorString)) {
			Debug.Log (note);
			Debug.Log(colorString);
			ScoreController.changeScore ();
			sr.color = new Color(sr.color.r + .3f, sr.color.g+.3f, sr.color.b+.3f, 1);
		}
		else {
			sr.color = new Color(0, 0, 0, 1);
		}
		ScoreController.changeTotal ();
	}
}
