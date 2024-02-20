using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	public void startGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}


	public static string getSong (string songName) 
	{
		string filePath = "Songs/" + songName;
		print (filePath);
		var textFile = Resources.Load<TextAsset>(filePath);
		return textFile.text;



	}

	public static List<string> getSongNames() 
	{

		string folderPath = "Songs";

		UnityEngine.Object[] assets = Resources.LoadAll<TextAsset>(folderPath);
		List<string> songNames = new List<string>();
		foreach (UnityEngine.Object asset in assets)
		{
			
			String name = asset.name.Split ('.')[0];
			Debug.Log (name);
			songNames.Add (name);
	
		}
		return songNames;
	}
		
}
