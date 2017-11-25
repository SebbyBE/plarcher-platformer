using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

	public static Player INSTANCE;

	public int speed = 5;
	public LayerMask groundLayer;
	public float groundDistance = 0.6f;
	public float jumpStrength = 7f;
	public bool isGrounded = false;

	public int coins = 0;

	public Rigidbody2D rigidBody;

	private ArrayList actionsList;

	// Use this for initialization
	void Start () {
		INSTANCE = this;
	}

	void FixedUpdate(){
		if (Physics2D.Raycast (transform.position, Vector2.down, groundDistance, groundLayer)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}

	public void addPower (PowerInfos infos)
	{
		Type monoB = Type.GetType (infos.name);
		if (monoB != null) {//mono behaviour exists
			if ((this.GetComponent (monoB)) == null) {//Player doesn't have the component
				if ((this.GetComponent<RemoveCoin> ()) == null) {//Player doesn't have the RemoveCoin script
					print ("Player needs to have the RemoveCoin script");
				} else {
					if (this.GetComponent<RemoveCoin> ().removeCoin (infos.price)) {//Check if player has enough money to buy
						Component ret = this.gameObject.AddComponent (monoB);//try to add behaviour
						if (ret == null) {
							print ("error adding " + infos.name);
						} else {
							print ("added " + infos.name + " to " + ret.name);
						}
					} else {
						print ("not enough money !");
					}
				}
			} else {
				print ("player already has component");
			}
		} else {//wrong name entered
			print ("the monobehaviour's name is wrong");
		}
	}
}
