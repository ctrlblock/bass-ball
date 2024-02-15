using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderBoardBehavior : MonoBehaviour {

	public static List<string> findSongRecord(string recordName) {
		string filePath = "Assets/Records/topscores.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(filePath); 
		string line = reader.ReadLine();
		while (line != null) {
			string[] splitLine = line.Split (new char[] { ',' });
			if (splitLine[0].Equals(recordName)) {
				Debug.Log (line);
				return new List<string> (splitLine);
			}
			line = reader.ReadLine();
		
		}
		Debug.Log ("NOT FOUND");
		reader.Close();
		return new List<string>();
	}

	public static void updateSongRecord(string recordName, int newScore) {
		string filePath = "Assets/Records/topscores.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(filePath); 
		string document = "";
		bool songFound = false;
		string line = reader.ReadLine();
		while (line != null) {
			string[] splitLine = line.Split (new char[] { ',' });
			List<string> lineList = new List<string>(splitLine); 
			if (splitLine [0].Equals (recordName)) {
				songFound = true;
				bool added = false;
				//calculate new records for this song
				for(int i = 1; i < lineList.Count; i++) {
					if(newScore > int.Parse(lineList[i])) {
						lineList.Insert (i, newScore.ToString());
						added = true;
						if(lineList.Count > 11)
							lineList.RemoveAt (11);
						break;
					}
				}
				if (lineList.Count < 11 && !added) {
					lineList.Add (newScore.ToString());
				}

			}
			document+= string.Join (",", lineList.ToArray ()) + '\n';
			line = reader.ReadLine();
		}
		if (!songFound) {
			document += '\n' + recordName + "," + newScore.ToString ();
		}

		reader.Close();
		StreamWriter writer = new StreamWriter (filePath);
		writer.Write (document);
		writer.Close ();
	}
}
