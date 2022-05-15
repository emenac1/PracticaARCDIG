using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtroBalonBehaviour : MonoBehaviour {
	public Button otroBalon;
	// Use this for initialization
	void Start () {
		Button btn = otroBalon.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick(){
		print ("Click repetir");
		Controlador.controlador.repetir ();
	}
}
