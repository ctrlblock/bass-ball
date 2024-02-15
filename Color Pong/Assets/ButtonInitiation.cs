using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInitiation : MonoBehaviour {

	public GameObject button;
	// Use this for initialization
	void Start () {
		initiateButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		

	public void initiateButtons() {
		List<string> filePaths = ButtonBehavior.TryGetUnityObjectsOfTypeFromPath ("Assets/Songs");
		for (int i = 0; i < filePaths.Count; i++) {
			GameObject button1 = Instantiate (button, gameObject.transform);
			button1.GetComponentInChildren<Text> ().text = filePaths [i].Split ('\\') [1];
			button1.SetActive (true);
			Debug.Log (button1);
		}
	}
}
