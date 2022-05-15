using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolverBehaviour : MonoBehaviour {
	public Button volver;
	public Transform PanelJuego;
	public Transform PanelInicial;
	// Use this for initialization
	void Start () {
		Button btn = volver.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick(){
		print ("Click volver");
		PanelJuego.gameObject.SetActive (false);
		PanelInicial.gameObject.SetActive (true);

	}
}
