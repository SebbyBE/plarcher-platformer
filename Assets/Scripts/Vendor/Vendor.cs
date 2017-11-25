using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour {

	public bool canInteract = false;
	public GameObject panel;

	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
			canInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D player){
		if (player.tag == "Player") {
			canInteract = false;
			panel.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3") && canInteract) {
			print ("Fire 3 pressed and can Interact");
			panel.SetActive (!panel.activeSelf);
		}
	}
}
