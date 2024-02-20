using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour {
	public GameObject ball;
	public GameObject ballCopy;
	public Color color = Color.red;
	public string colorString;
	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.color = color;
	}

	public void fire(string songNote) {
		ballCopy = Instantiate (ball);
		ballCopy.transform.position = transform.position;
		ballBehavior ballScript = ballCopy.GetComponent<ballBehavior> ();
		ballScript.setColor (color, songNote);
	}
	
	// Update is called once per frame
	void Update () {

	}

}
