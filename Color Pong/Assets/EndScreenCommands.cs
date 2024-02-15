using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreenCommands : MonoBehaviour {

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
}

