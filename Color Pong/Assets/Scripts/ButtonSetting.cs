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
		if (SongSelector.songName != "Random1" && SongSelector.songName != "Random2") { 
			SongSelector.songName = GetComponentInChildren<Text>().text;
		}
	}

	public void setLeaderBoard() {
		lbt.GetComponent<LeaderBoardText>().displayLeaderBoard(LeaderBoardBehavior.findSongRecords (GetComponentInChildren<Text> ().text));
	}
}
