using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Events;

public class Timer : MonoBehaviour {

	private int timeLeft;
	public IntEvent uiUpdate;
	public GameObject uiTimer;
	public GameObject uiTimerValue;

	public void StartTimer(int seconds){
		//on affiche les éléments dans l'UI affichant les textes concernant le timer
		uiTimer.SetActive (true);
		uiTimerValue.SetActive (true);
		StopCoroutine(TimerManagement());
		this.timeLeft = seconds;
		StartCoroutine(TimerManagement());
	}

	private IEnumerator TimerManagement(){
		//tant que le temps restant du timer est supérieur a 0 on décrémente et affiche dans la GUI
		while (this.timeLeft > 0) {
			uiUpdate.Invoke (timeLeft);
			timeLeft--;
			yield return new WaitForSeconds (1);
		}
		uiTimer.SetActive (false);
		uiTimerValue.SetActive (false);
	}
}
