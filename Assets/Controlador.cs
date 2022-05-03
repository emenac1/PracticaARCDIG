using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour {

	//EN DefaultTrackableEventHandler POSIBLEMENTE ESTÉ EL FALLO, MIRAR
	private Vector3[] balones;
	bool bolaCreada;
	public GameObject bola;
	// Use this for initialization
	void Start () {
		balones = new Vector3[5];
		bolaCreada = false;
		bola = GameObject.Find ("Bola");
	}
	
	// Update is called once per frame
	void Update () {
		if (!bolaCreada && balones [0] != Vector3.zero) {
			bola = new GameObject ("Bola");
			bola.SetActive (true);
			 
		}

			
	}

	public void nuevoBalon (Vector3 posicion) {
		bool noCreado = true;
		for (int i = 0; i < 5 && noCreado; i++) {
			if (balones [i] == Vector3.zero){
				balones [i] = posicion;
				noCreado = false;
			}
			print (balones [i]);
		}

	}

	public void borrarBalon (Vector3 posicion) {
		bool noBorrado = true;
		for (int i = 0; i < 5 && noBorrado; i++) {
			if (balones [i] == posicion){
				balones [i] = Vector3.zero;
				noBorrado = false;
			}
			print (balones [i]);
		}

	}
		
}
