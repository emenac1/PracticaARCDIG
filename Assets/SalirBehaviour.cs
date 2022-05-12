using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SalirBehaviour : MonoBehaviour {
	public Button salir;
	public Transform PanelCreditos;
	public Transform PanelJugar;
	// Use this for initialization
	void Start () {
		Button btn = salir.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick(){
		print ("Click jugar");
		PanelJugar.gameObject.SetActive (true);
		PanelCreditos.gameObject.SetActive (false);

	}
}
