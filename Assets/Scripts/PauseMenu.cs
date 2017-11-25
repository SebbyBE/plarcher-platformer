using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	private bool isPaused = false;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
			if (isPaused) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	}
}
