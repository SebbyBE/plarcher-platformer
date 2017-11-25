using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using My.Events;

public class Player : MonoBehaviour {

	public static Player INSTANCE;

	public int speed = 5;
	public LayerMask groundLayer;
	public float groundDistance = 0.6f;
	public float jumpStrength = 7f;
	public bool isGrounded = false;
	public bool isClimbing = false;

	public bool lookRight;

	public int coins = 0;

	public Rigidbody2D rigidBody;

	private ArrayList actionsList;

	public IntEvent OnCoinCahnge;

	// Use this for initialization
	void Start () {
		INSTANCE = this;
		this.gameObject.AddComponent<RightComponent> ();
		this.gameObject.AddComponent<GetCoin> ();
		lookRight = true;
	}

	void OnEnable(){
		OnCoinCahnge.Invoke (0);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")){
			this.gameObject.AddComponent<LeftComponent> ();
			this.gameObject.AddComponent<Jump> ();
			this.gameObject.AddComponent<ClimbingLadders> ();
		}
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
	void SetCoins(int newCoins){
		coins = newCoins;
		OnCoinCahnge.Invoke (coins);
	}

	public void AddCoin(){
		coins++;
		SetCoins (coins);
	}


}
