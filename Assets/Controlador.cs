using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour {

	//EN DefaultTrackableEventHandler POSIBLEMENTE ESTÉ EL FALLO, MIRAR
	private Vector3[] balones;
	bool bolaCreada;
	public movimientoBola bola;
	public static Controlador controlador;
	// Use this for initialization

	public void Awake(){
		controlador = this;
		balones = new Vector3[5];
		bolaCreada = false;
		//bola = GameObject.Find ("Bola");
		for (int i = 0; i < 5; i++)
			balones [i] = Vector3.zero;
	}


	void Start () {
		balones = new Vector3[5];
		bolaCreada = false;
		//bola = GameObject.Find ("Bola");
		for (int i = 0; i < 5; i++)
			balones [i] = Vector3.zero;
	}


	// Update is called once per frame
	void Update () {
		if (!bolaCreada && balones [0] != Vector3.zero) {
			//bola = new GameObject ("Bola");
			//bola.SetActive (true);
			bola = gameObject.AddComponent (typeof(movimientoBola)) as movimientoBola;
			bolaCreada = true;
		}

			
	}

	public int nuevoBalon (Vector3 posicion) {
		bool noCreado = true;
		int pos = -1;
		if (!bolaCreada) {
			//bola = new GameObject ("Bola");
			//bola.SetActive (true);
			bola = gameObject.AddComponent (typeof(movimientoBola)) as movimientoBola;
			bolaCreada = true;
		}
		print ("la lista de balones es: ");
		for (int i = 0; i < 5 && noCreado; i++) {
			if (balones [i] == Vector3.zero){
				balones [i] = posicion;
				noCreado = false;
				pos = i;
			}

			print (balones [i]);
		}
		movimientoBola.bola.setRuta(balones);
		return pos;

	}

	public void borrarBalon (int posicion) {
		bool vacio = false;
		if(posicion != -1)
			balones [posicion] = Vector3.zero;
		for (int i = 0; i < 5 && !vacio; i++) {
			if (balones [i] != Vector3.zero)
				vacio = true;
		}
		if (vacio) {
			movimientoBola.bola.destruir ();
			print ("bola borrada");
		} else {
			movimientoBola.bola.setRuta (balones);
			print ("balon borrado");
		}

	}
		
}
