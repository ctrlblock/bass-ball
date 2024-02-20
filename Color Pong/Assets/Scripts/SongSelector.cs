using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelector : MonoBehaviour {
	public static string songName = "Random";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setSongRandom() {
		songName = "Random1";
	}

	public void setSongRandom2() {
		songName = "Random2";
	}

}
