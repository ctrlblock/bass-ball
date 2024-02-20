using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {
	private float speed = 160f;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Vertical")*Time.deltaTime*speed;
		transform.Translate (0, move, 0);
		string note = "";
		int r = 0;
		int g = 0;
		int b = 0;
		//Debug.Log (transform.position);
		if (Input.GetAxis ("Fire1") > .1) {
			note = "red";
			r = 1;
			//Debug.Log ("Red");
		}
		if (Input.GetAxis ("Fire2") > .1) {
			note = "green";
			g = 1;
			//Debug.Log("Green");
		}
		if (Input.GetAxis ("Fire3") > .1) {
			note = "blue";
			b = 1;
			//Debug.Log("Blue");
		}
		if (!note.Equals ("")) {
			sr.color = new Color ((float)r, (float)g, (float)b, 1);
		} else {
			sr.color = new Color (1.0f, 1.0f, 1.0f, 1);
		}

	}
}
