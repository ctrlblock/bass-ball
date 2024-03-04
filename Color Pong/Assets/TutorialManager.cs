using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

	public string[] textPrompts = { "Press w and s to move up and down.",
									"Turn red by holding down 'p'.",
									"Here comes a red orb.",
									"Move to hit it, and hold down 'p'",
									"Hold down the '[' key to turn green.",
									"Here comes a green orb. Hit it while pressing '['.",
									"And finally, blue. Hold down ']' for blue.",
									""};

	public Text text;

	private float[] textChangeIntervals = { 2.5f, 20, 28.75f, 37.5f, 50f, 66f, 85, 1000};

	private int currentInterval = 0;

	void Start() {
		//can be based on both time and score
		text.text = "Press w and s to move up and down";
    }

	public void updateTutorial(double time) {
		if (time > textChangeIntervals[currentInterval]) {
			incrementText();
		}
	}

	void incrementText() {
		text.text = textPrompts[currentInterval];
		currentInterval++;
	}

}
