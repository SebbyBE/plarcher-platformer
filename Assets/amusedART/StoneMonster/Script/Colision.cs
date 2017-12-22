using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Food") {
			Player.INSTANCE.Heal (1);
			Destroy (col.transform.parent.gameObject);
		}
		if (col.tag == "EnemySide") {
			if (!Player.INSTANCE.isInvincible) {
				Player.INSTANCE.TakeDamage (1);
				if (col.name == "EnemySideRight") {
					
					/*
					If the player looks right and the enemy hits from the front of his head, the player must be pushed to the right side
					*/
					if (Player.INSTANCE.lookRight) {
						Player.INSTANCE.rigidBody.AddForce ((Vector3.right * 5) + (Vector3.up * 3), ForceMode2D.Impulse);	
					}

					/*
					If the player looks left and the enemy hits from the the front of his head, the player must be pushed to the left side
					*/
					else {
						Player.INSTANCE.rigidBody.AddForce ((Vector3.left * 5) + (Vector3.up * 3), ForceMode2D.Impulse);
					}
				}
				if (col.name == "EnemySideLeft") {
					
					/*
					If the player looks right and hits the enemy from the back(spiky side), the player must be pushed to the left side
					*/
					if (Player.INSTANCE.lookRight) {
						Player.INSTANCE.rigidBody.AddForce ((Vector3.left * 8) + (Vector3.up * 3), ForceMode2D.Impulse);	
					}

					/*
					If the player looks left and hits the enemy from the back(spiky side), the player must be pushed to the right side
					*/
					else {
						Player.INSTANCE.rigidBody.AddForce ((Vector3.right * 8) + (Vector3.up * 3), ForceMode2D.Impulse);
					}
				}
			}
		}
		if (col.tag == "EnemyHead") {
			//Chek if player is invincible, he cannot deal damage if he's invincible, to broken
			if (!Player.INSTANCE.isInvincible) {
				//make the player jump, like Mario on the head of the enemy
				Player.INSTANCE.rigidBody.AddForce (Vector3.up * 10,ForceMode2D.Impulse);

				//Nedd the animation made by the asset from the market to have the death animation of the enemy
				Animation_Test at = col.transform.parent.parent.gameObject.GetComponent<Animation_Test> ();

				//deactivate the colliders from front and back, so he can't deal damage
				col.transform.parent.parent.Find ("EnemySideLeft").gameObject.SetActive (false);
				col.transform.parent.parent.Find ("EnemySideRight").gameObject.SetActive (false);

				//deactiate the last collider because it's not needed.
				col.gameObject.SetActive (false);

				//stop the enemy from moving, he's dead
				col.transform.parent.parent.GetComponent<Patroling> ().canMove = false;

				//launch death animation
				at.DeathAni ();

				//launch Coroutine, to have the animation display, then the enemy disapear
				StartCoroutine (die (col));
			}
		}
	}

	private IEnumerator die(Collider2D col){
		yield return new WaitForSeconds(2);
		Destroy (col.transform.parent.parent.gameObject);
		StopCoroutine ("die");
	}
}
