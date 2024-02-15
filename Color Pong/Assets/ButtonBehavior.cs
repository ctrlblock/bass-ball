using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	public void startGame() {
		Debug.Log (TryGetUnityObjectsOfTypeFromPath("Assets/Songs"));
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public static List<string> TryGetUnityObjectsOfTypeFromPath (string path) 
	{
		string[] filePaths = System.IO.Directory.GetFiles (path);
		List<string> usefulFP = new List<string>();
		for(int i = 0; i < filePaths.Length; i++){
			String[] s = filePaths[i].Split ('.');
			if (s [s.Length - 1] == "txt") {
				usefulFP.Add (s [s.Length - 2]);
				Debug.Log (filePaths[i]);
			}
			}
		return usefulFP;
	}
		
}
