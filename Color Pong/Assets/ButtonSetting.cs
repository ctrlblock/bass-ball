using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSetting : MonoBehaviour {
	// Use this for initialization
	public GameObject lbt;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSong() {
		SongSelector.songName = GetComponentInChildren<Text> ().text;
		if (SongSelector.songName == "Random") {
			SongSelector.songPath = "Random";
		} else {
			SongSelector.songPath = "Assets/Songs/" + GetComponentInChildren<Text> ().text + ".txt";
		}
		Debug.Log (SongSelector.songPath);
	}

	public void setLeaderBoard() {
		lbt.GetComponent<LeaderBoardText>().displayLeaderBoard(LeaderBoardBehavior.findSongRecord (GetComponentInChildren<Text> ().text));
	}
}
