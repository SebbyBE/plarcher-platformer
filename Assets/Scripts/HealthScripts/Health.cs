using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Events;

public class Health : MonoBehaviour {
	public int currentHealth;
	private int initHealth = 3;

	public IntEvent OnHealthChange;

	void OnEnable(){
		currentHealth = initHealth;
		UpdateHealth ();
	}

	public void UpdateHealth(){
		//Update l'UI concernée
		OnHealthChange.Invoke (this.currentHealth);
	}

	public void TakeDamage(int damage){
		currentHealth -= damage;
		UpdateHealth ();
		if (currentHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	public void Heal(int heal){
		currentHealth += heal;
		UpdateHealth ();
	}
}
