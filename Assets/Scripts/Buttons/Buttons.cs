using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	private static int activatedButtons;
	private MeshRenderer render;

	private int openFirstDoor = 2;

	// Use this for initialization
	void Start () {
		activatedButtons = 0;
		render = GetComponentInParent<MeshRenderer> ();
		render.material.color = Color.red;
	}
	
	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
			activatedButtons++;
			render.material.color = Color.green;
			switch (activatedButtons) {
			case 1:
				Player.INSTANCE.Talk ("Hey the button changed color.\nIt probably did something");
				break;
			case openFirstDoor:
				Player.INSTANCE.Talk ("I think I heard something,\nmaybe something happened ?");
				//todo add following part
				break;
			}
		}
	}
		
}
