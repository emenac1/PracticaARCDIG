using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreditoBehaviour : MonoBehaviour {
	public Button creditos;
	public Transform PanelCreditos;
	public Transform PanelInicial;
	// Use this for initialization
	void Start () {
		Button btn = creditos.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	// Update is called once per frame
	void Update () {

	}

	public void TaskOnClick(){
		print ("Click jugar");
		PanelInicial.gameObject.SetActive (false);
		PanelCreditos.gameObject.SetActive (true);

	}
}