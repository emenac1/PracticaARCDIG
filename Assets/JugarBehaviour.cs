using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarBehaviour : MonoBehaviour {

	public Button jugar;
	public Transform PanelInicial;
	public Transform PanelJuego;


	// Use this for initialization
	void Start () {
		Button btn = jugar.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void TaskOnClick(){
		print ("Click jugar");
		PanelInicial.gameObject.SetActive (false);
		PanelJuego.gameObject.SetActive (true);


	}
}
