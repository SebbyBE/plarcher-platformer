using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitGudSon : MonoBehaviour {

	private string[] cheatCode;
	private int index;
	private bool cheatOn;

	void Start () {
		cheatCode = new string[]{ "g", "i", "t", "g", "u", "d", "s", "o", "n" };
		index = 0;
		cheatOn = false;
	}

	void Update () {
		if (Input.anyKeyDown) {
			if(Input.GetKeyDown(cheatCode[index])){
				index++;
			}else{
				index = 0;		
			}
		}

		if (!cheatOn && index == cheatCode.Length) {
			gameObject.AddComponent<LeftComponent> ();
			gameObject.AddComponent<Jump> ();
			gameObject.AddComponent<ClimbingLadders> ();
			gameObject.AddComponent<DoubleJump> ();
			gameObject.AddComponent<RunComponent> ();
			Buttons.activatedButtons = 2;
			Player.INSTANCE.secretDoor.Invoke ();
			cheatOn = !cheatOn;
		}
	}
}
