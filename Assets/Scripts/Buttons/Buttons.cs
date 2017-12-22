using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Events;

public class Buttons : MonoBehaviour {

	public static int activatedButtons;
	private MeshRenderer render;

	public MyEvent secretDoor;
	public MyEvent timerMiniGame;

	private bool activated = false;

	void Start () {
		//le nombre de boutons qui ont déja été activés
		activatedButtons = 0;
		render = GetComponentInParent<MeshRenderer> ();
		//On change la couleur du bouton en rouge parce qu'il n'est pas activé par défaut
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
				//ouvre la porte secrete
				secretDoor.Invoke ();
				break;
			case 3:
				Player.INSTANCE.Talk ("Quickly ! I need to get to the other side !");
				timerMiniGame.Invoke ();
				StartCoroutine (TimeOutDoor ());
				//lance un timer dans l'UI de 15 secondes
				GetComponent<Timer> ().StartTimer (15);
				break;
			}
		}
	}

	private IEnumerator TimeOutDoor(){
		//permet au joueur de réactiver le bouton apres le timer passé
		yield return new WaitForSeconds (15);
		this.activated = false;
		activatedButtons--;
		render.material.color = Color.red;
	}
}
