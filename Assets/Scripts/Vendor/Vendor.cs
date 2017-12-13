using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendor : MonoBehaviour {

	public bool canInteract = false;
	public GameObject panel;
	public List<PowerInfos> infos;
	private GameObject buttonPrefab;

	void Start(){
		buttonPrefab = (GameObject)Resources.Load ("Vendor/Power Button");
		GameObject listofpower = panel.transform.Find("List Contrainer/ListOfPowers").gameObject;
		foreach(PowerInfos p in infos){
			GameObject newButton = Instantiate (buttonPrefab);
			newButton.transform.SetParent(listofpower.transform);
			newButton.GetComponentInChildren<Text> ().text = p.name + "\t" + p.price;
			Button b = newButton.GetComponent<Button> ();
			b.onClick.AddListener(() => Player.INSTANCE.addPower(p));
		}
	}

	void OnTriggerEnter2D(Collider2D player){
		print ("enter collision");
		if (player.tag == "Player") {
			canInteract = true;
		}
	}

	void OnTriggerExit2D(Collider2D player){
		if (player.tag == "Player") {
			canInteract = false;
			panel.SetActive (false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3") && canInteract) {
			print ("panel activé");
			panel.SetActive (!panel.activeSelf);
		}
	}
}
