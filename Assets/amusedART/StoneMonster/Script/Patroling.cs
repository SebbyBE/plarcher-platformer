using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroling : MonoBehaviour {
	public int patrolSize = 10;
	private int patrolMove = 0;

	private bool left=false;
	[HideInInspector]
	public bool canMove = true;

	private float groundDistance = 1f;

	public LayerMask groundLayer;

	void OnEnable(){
		patrolMove = patrolSize / 2;
	}

	void Update(){
		Move ();
	}

	void FixedUpdate(){
		if (!Physics2D.Raycast (transform.position, Vector2.down, groundDistance, groundLayer)) {
			Flip();
		}
	}

	void Move(){
		if (canMove) {
			if (!left) {
				if (patrolMove == patrolSize) {
					Flip ();
				} else if(patrolMove < patrolSize +1){
					Right ();
				}
			}
			if (left) {
				if (patrolMove == 0) {
					Flip ();
				}else if(patrolMove > -1){
					Left();
				}
			}
		}
	}

	void Right(){
		transform.Translate (Vector3.forward * Time.deltaTime);
		patrolMove++;
	}

	void Left(){
		transform.Translate (Vector3.back * Time.deltaTime);
		patrolMove--;
	}

	void Flip(){
		left = !left;
		Vector3 scale = transform.localScale;
		scale.z *= -1;
		transform.localScale = scale;
	}
}
