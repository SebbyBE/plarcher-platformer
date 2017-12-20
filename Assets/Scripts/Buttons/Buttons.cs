using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Events;

public class Buttons : MonoBehaviour {

	private static int activatedButtons;
	private MeshRenderer render;

	public MyEvent toInvoke;

	private bool activated = false;

	// Use this for initialization
	void Start () {
		activatedButtons = 0;
		render = GetComponentInParent<MeshRenderer> ();
		render.material.color = Color.red;
	}
	
	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player" && !this.activated) {
			activatedButtons++;
			this.activated = true;
			render.material.color = Color.green;
			switch (activatedButtons) {
			case 1:
				Player.INSTANCE.Talk ("Hey the button changed color.\nIt probably did something");
				break;
			case 2:
				Player.INSTANCE.Talk ("I think I heard something,\nmaybe something happened ?");
				toInvoke.Invoke ();
				break;
			}
		}
	}
		
}
