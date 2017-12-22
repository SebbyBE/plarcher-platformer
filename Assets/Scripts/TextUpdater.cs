using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour {

	public Text text;
	public Text health;
	public Text Timer;


	public void ChangeText(string newText) {
		text.text = newText;
	}

	public void ChangeText(int newText) {
		ChangeText ("" + newText);
	}

	public void UpdateHealth(string newHealth){
		health.text = newHealth;
	}

	public void UpdateHealth(int newHealth){
		UpdateHealth ("" + newHealth);
	}

	public void UpdateTime(string newTime){
		Timer.text = newTime;
	}

	public void UpdateTime(int newTime){
		UpdateTime("" + newTime);
	}



}
