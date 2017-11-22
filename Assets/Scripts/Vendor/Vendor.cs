using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour {

	private bool canInteract = false;
	public GameObject panel;

	void OnTriggerEnter2D(Collider2D vendor){
		print ("coll");
		if (vendor.tag == "Player") {
			canInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D vendor){
		if (vendor.tag == "Player") {
			canInteract = false;
			panel.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3") && canInteract) {
			panel.SetActive (!panel.activeSelf);
		}
	}
}
