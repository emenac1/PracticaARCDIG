using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JugarBehaviour : MonoBehaviour {

	public Button jugar;
	public Transform PanelJugar;


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
		PanelJugar.gameObject.SetActive (false);

	}
}
