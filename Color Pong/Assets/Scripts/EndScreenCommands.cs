﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenCommands : MonoBehaviour {

	public UnityEngine.UI.Text scoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void mainMenu() {
		SceneManager.LoadScene (0);
	}

	public void playAgain() {
		SceneManager.LoadScene (1);
	}

	public void setScore (int score) {
		scoreText.text = "Score : " + score;
	
	}
}

