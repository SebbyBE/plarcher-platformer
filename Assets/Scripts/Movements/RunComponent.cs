using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunComponent : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
			Player.INSTANCE.speed *= 1.5f;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.RightShift)) {
			Player.INSTANCE.speed /= 1.5f;
		}
	}
}
