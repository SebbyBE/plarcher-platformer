using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "EnemySide") {
			if (!Player.INSTANCE.isInvincible) {
				Player.INSTANCE.TakeDamage (1);
				if (col.name == "EnemySideRight") {
					Player.INSTANCE.rigidBody.AddForce ((Vector3.right * 5) + (Vector3.up * 3),ForceMode2D.Impulse);
				}
				if (col.name == "EnemySideleft") {
					Player.INSTANCE.rigidBody.AddForce ((Vector3.left * 5) + (Vector3.up * 3),ForceMode2D.Impulse);
				}
			}
		}
		if (col.tag == "EnemyHead") {
			if (!Player.INSTANCE.isInvincible) {
				Player.INSTANCE.rigidBody.AddForce (Vector3.up * 10,ForceMode2D.Impulse);
				Animation_Test at = col.transform.parent.parent.gameObject.GetComponent<Animation_Test> ();
				col.transform.parent.parent.Find ("EnemySideLeft").gameObject.SetActive (false);
				col.transform.parent.parent.Find ("EnemySideRight").gameObject.SetActive (false);
				col.gameObject.SetActive (false);
				col.transform.parent.parent.GetComponent<Patroling> ().canMove = false;
				at.DeathAni ();
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
