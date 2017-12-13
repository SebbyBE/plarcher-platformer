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

	[HideInInspector]
	public Animator anim;

	[HideInInspector]
	public bool lookRight;

	public int coins = 0;

	public Rigidbody2D rigidBody;

	private ArrayList actionsList;

	public IntEvent OnCoinChange;

	// Use this for initialization
	void Start () {
		INSTANCE = this;
		lookRight = true;
		anim = GetComponentInChildren<Animator> ();
	}

	void OnEnable(){
		UpdateCoins ();
	}
		
	void FixedUpdate(){
		if (Physics2D.Raycast (transform.position, Vector2.down, groundDistance, groundLayer)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
		anim.SetBool ("IsGrounded", isGrounded);
		anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.O)) {
			this.gameObject.AddComponent<LeftComponent> ();
			this.gameObject.AddComponent<Jump> ();
			this.gameObject.AddComponent<ClimbingLadders> ();
			this.gameObject.AddComponent<DoubleJump> ();
		}
	}

	public void Flip(){
		lookRight = !lookRight;
		transform.localScale *= -1;
	}

	public void addPower (PowerInfos infos)
	{
		Type monoB = Type.GetType (infos.name);
		if (monoB != null) {//mono behaviour exists
			if ((this.GetComponent (monoB)) == null) {//Player doesn't have the component
				if (RemoveCoin (infos.price)) {//Check if player has enough money to buy
					Component ret = this.gameObject.AddComponent (monoB);//try to add behaviour
					if (ret == null) {
						print ("error adding " + infos.name);
					} else {
						print ("added " + infos.name + " to " + ret.name);
					}
				} else {
					print ("not enough money !");
				}
			} else {
				print ("player already has component");
			}
		} else {//wrong name entered
			print ("the monobehaviour's name is wrong");
		}
	}

	private void UpdateCoins(){//set coins in UI
		OnCoinChange.Invoke (coins);
	}

	public void AddCoin(){
		coins++;
		UpdateCoins ();
	}

	public bool RemoveCoin(int amount){
		if ((coins - amount) < 0) {
			return false;
		} else {
			coins -= amount;
			UpdateCoins ();
			return true;
		}
	}
}
