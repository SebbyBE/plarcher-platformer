using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	public int currentHealth;
	private int initHealth = 3;

	void OnEnable(){
		currentHealth = initHealth;
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
		if (currentHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void Heal(int heal){
		currentHealth += heal;
	}
}
