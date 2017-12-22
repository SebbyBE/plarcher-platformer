using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D player){
		if (player.tag == "Player") {
				Player.INSTANCE.Talk ("Yes I did it ! I can now quit the game\nor restart by pressing the Esc key");
		}
	}

}
