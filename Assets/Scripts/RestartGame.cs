using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public GameObject dieMenu;

	public void Restart(){
		dieMenu.SetActive (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}
