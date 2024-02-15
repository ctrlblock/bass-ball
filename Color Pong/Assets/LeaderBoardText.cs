using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void displayLeaderBoard(List<string> board) {
		string finalText = SongSelector.songName + ":\n";
		for (int i = 1; i < board.Count; i++) {
			finalText += board[i] + "\n\n";
		}
		GetComponent<Text> ().text = finalText;
	}
		
}
