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
		string finalText = SongSelector.songName + "\n\n";
		finalText += "Top Scores:\n\n";
		for (int i = 1; i < board.Count; i++) {
			string[] recordTuple = board[i].Split (new char[] { ':' });
			finalText += i + ".  " + recordTuple[1] + "\n\n";
		}
		GetComponent<Text> ().text = finalText;
	}
		
}
