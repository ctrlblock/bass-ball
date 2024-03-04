using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderBoardBehavior : MonoBehaviour {

	public static string defaultScores = "DoubleNotes,A:10;"
		+ "Random2,A:80,A:78;";

	public static string loadRecords() {
		//FOR TESTING ONLY. TO KEEP DATA CONSISTENT
		//PlayerPrefs.SetString("TopScores", defaultScores);
		print (PlayerPrefs.GetString ("TopScores", defaultScores));
		return PlayerPrefs.GetString ("TopScores", defaultScores);
	}

	public static void saveRecords(string record) {
		PlayerPrefs.SetString("TopScores", record);
	}
	public static List<string> findSongRecords(string recordName) {
		string records = loadRecords();
		List<string> songScores = new List<string>(records.Split(new char[] { ';' }));
		for(int i = 0; i < songScores.Count; i++) {
			string[] items = songScores[i].Split (new char[] { ',' });
			if (items[0].Equals(recordName)) {
				return new List<string> (items);
			}
		}
		Debug.Log ("NOT FOUND");
		return new List<string>();
	}

	public static void updateSongRecord(string recordName, int newScore) {
		
		string document = "";
		bool songFound = false;
		string newRecord = "A:" + newScore.ToString();

		string records = loadRecords();
		List<string> songRecordsList = new List<string>(records.Split(new char[] { ';' }));


		for(int i = 0; i < songRecordsList.Count; i++) {
			List<string> songRecords = new List<string>(songRecordsList[i].Split(new char[] { ',' }));
			if (songRecords[0].Equals (recordName)) {
				songFound = true;
				bool added = false;
				//calculate new records for this song
				for(int j = 1; j < songRecords.Count; j++) {
					string[] scoreTuple = songRecords [j].Split (new char[] { ':' });
					int score = int.Parse(scoreTuple[1]);
					if(newScore > score) {
						songRecords.Insert (j, newRecord);
						added = true;
						if(songRecords.Count > 11)
							songRecords.RemoveAt (11);
						break;
					}
				}
				if (songRecords.Count < 10 && !added) {
					songRecords.Add (newRecord);
				}

			}
			if (i > 0) {
				document += ";";
			}
			document += string.Join (",", songRecords.ToArray ());
		}
		if (!songFound) {
			document += ";" + recordName + "," + newRecord;
		}
		saveRecords (document);
	}
}
