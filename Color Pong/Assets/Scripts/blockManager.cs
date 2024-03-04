using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class blockManager : MonoBehaviour {
	public SongSupplier songSupplier;

	bool isEasyEnabled = true;

	//the OrderedDictionary enumerator is not treating me kindly, so for now I am just implementing 2 lists
	private List<int> songTimes = new List<int>();
	private List<string> songNotes = new List<string>();
	int timer = 0;
	int totalNotes = 0;
	private int notesSent = 0;
	public int numberBlocks = 3;
	bool random = false;
	bool tutorial = false;
	public List<fireBall> blocks = new List<fireBall>();
	public TutorialManager noteObject;
	public bool triggered = false;
	public ScoreController sc;
	float startTime = 0;
	public GameObject tutorialManager;

	public GameObject endScreen;
	// Use this for initialization
	void Start () {
		readSong ();
		Debug.Log ("BlockManager started");
		foreach (Transform child in transform) {
			if (child.gameObject.tag == "Block") {
				blocks.Add (child.gameObject.GetComponent<fireBall>());
			}
		}
		startGame ();

	}
	
	// Update is called once per frame
	void Update () {
		if (ScoreController.total >= totalNotes) {
			endGame ();
		}
		//SongSupplier could supply its own coefficient here, to change speed
		//print(notesSent);
		//print(totalNotes);
		if ((int)((Time.time-startTime)*songSupplier.getSongSpeed()) -3 > timer && notesSent < totalNotes) {
			timer++;
			if (!triggered) {
				if (random) {
					string noteUpdate = songSupplier.songUpdate(timer);
                    if (noteUpdate != null)
					{
						fireNotes(noteUpdate);
						notesSent+=noteUpdate.Length;
					}
                    triggered = true;
                } else {
					if (tutorial) {
                        tutorialManager.GetComponent<TutorialManager>().updateTutorial((Time.time - startTime) * songSupplier.getSongSpeed() - 3);
					}
					songUpdate (timer);
				}
			}
		} else { 
			triggered = false;
		}
	}

	void endGame() {
		LeaderBoardBehavior.updateSongRecord (SongSelector.songName, ScoreController.score);
		endScreen.GetComponent<EndScreenCommands>().setScore(ScoreController.score);
		endScreen.SetActive (true);
		GameObject.Find ("Game").SetActive (false);
	}

	void fireNotes(string notes) {
        for (int i = 0; i < notes.Length; i++)
        {
			//sends both notes to each block, so that the game can track which ones are intended for double color matching
            int blockNumber = int.Parse(notes[i].ToString());
			blocks[blockNumber].fire(notes);
        }
    }

	void songUpdate(int time) {
        if (songTimes.Count > notesSent) {
			if (songTimes [notesSent] == time) {
				fireNotes(songNotes[notesSent]);
				triggered = true;
                notesSent++;
			}
		}
	}

	void readSong() {
		if (SongSelector.songName == "1 - Sunday Stroll" | SongSelector.songName == "2 - Hopscotch" |
			SongSelector.songName == "3 - Heating Up" | SongSelector.songName == "4 - HellFire") {
			random = true;
			if (SongSelector.songName == "1 - Sunday Stroll")
			{
				songSupplier = new BeginnerRandomSongSupplier();
			}
            else if (SongSelector.songName == "2 - Hopscotch")
            {
                songSupplier = new EasyRandomSongSupplier();
            }
            else if (SongSelector.songName == "4 - HellFire") { 
				songSupplier = new HardRandomSongSupplier();
			}
			else
			{
				songSupplier = new RandomSongSupplier();
			}
            totalNotes = songSupplier.getNoteCount();

        } else {
            if (SongSelector.songName == "0 - Tutorial")
            {
				tutorial = true;
                tutorialManager.SetActive(true);
            }

            totalNotes = 0;
			songSupplier = new DefaultSongSupplier();
			string songData = ButtonBehavior.getSong (SongSelector.songName);
			string[] arr = songData.Split (',');
			for (int i = 0; i < arr.Length; i += 2 ) {
				songTimes.Add (int.Parse(arr [i])); 
				songNotes.Add(arr [i+1]);
				totalNotes += arr [i+1].Length;
			}
		}
	}

	public void resetForNextGame() {
		//The static variables persist through scenes, whereas the GameObjects are destroyed when scenes switch
		ScoreController.score = 0;
		ScoreController.total = 0;
		notesSent = 0;
		triggered = false;
		timer = 0;
	}

	public void startGame() {
		startTime = Time.time;
	}
}
