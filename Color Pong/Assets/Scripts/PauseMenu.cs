using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;

	public AudioSource songAudio;

	public GameObject pauseMenuUI;
	public GameObject blockManager;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Period)) {
			if(gameIsPaused) {
				Resume();
			}
			else{
				Pause();
			}
		}
		if (gameIsPaused) {
			if (Input.GetKeyDown(KeyCode.M)) {
				Resume();
				blockManager.GetComponent<blockManager>().resetForNextGame();
                SceneManager.LoadScene(0);
            }
		}
	}

	void Pause() {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		songAudio.Pause ();
		gameIsPaused = true;
		
	}

	void Resume() {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		songAudio.Play ();
		gameIsPaused = false;

	}

}
