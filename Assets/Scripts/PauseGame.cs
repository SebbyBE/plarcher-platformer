using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour {
	public Transform pauseCanvas;
	public GameObject dieMenu;

	void OnEnable(){
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!dieMenu.activeInHierarchy) {
				Pause ();
			}
		}	
	}

	public void Pause(){
		if (pauseCanvas.gameObject.activeInHierarchy == false) {
			pauseCanvas.gameObject.SetActive (true);
			Time.timeScale = 0;
		} else {
			pauseCanvas.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}
}
