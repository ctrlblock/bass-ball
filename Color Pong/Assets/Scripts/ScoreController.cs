using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public static int score = 0;
	public static int total = 0;


	public static void changeScore() {
		score++;
	}


	public static void changeTotal() {
		total++;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
