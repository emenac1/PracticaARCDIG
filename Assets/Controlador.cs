using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour {

	//EN DefaultTrackableEventHandler POSIBLEMENTE ESTÉ EL FALLO, MIRAR
	private Vector3[] balones;
	bool bolaCreada;
	public static Controlador controlador;

	public GameObject Bola;
	public GameObject instanciaBola;
	public Vector3 redbull;
	// Use this for initialization

	public void Awake(){
		redbull = Vector3.zero;
		controlador = this;
		balones = new Vector3[4];
		bolaCreada = false;
		//bola = GameObject.Find ("Bola");
		for (int i = 0; i < 4; i++)
			balones [i] = Vector3.zero;
	}


	void Start () {
		balones = new Vector3[4];
		bolaCreada = false;
		redbull = Vector3.zero;
		//bola = GameObject.Find ("Bola");
		for (int i = 0; i < 4; i++)
			balones [i] = Vector3.zero;
	}


	// Update is called once per frame
	void Update () {
					
	}

	public int nuevoBalon (Vector3 posicion) {
		bool noCreado = true;
		int pos = -1;
		if (!bolaCreada) {
			instanciaBola = (GameObject)Instantiate(Bola, posicion, Quaternion.identity);
			bolaCreada = true;
		}
		print ("la lista de balones es: ");
		for (int i = 0; i < 4 && noCreado; i++) {
			if (balones [i] == Vector3.zero){
				balones [i] = posicion;
				noCreado = false;
				pos = i;
			}

			print (balones [i]);
		}
		instanciaBola.GetComponent<movimientoBola>().setRuta(balones);
		return pos;

	}

	public void borrarBalon (int posicion) {
		bool noVacio = false;
		if(posicion != -1)
			balones [posicion] = Vector3.zero;
		for (int i = 0; i < 4 && !noVacio; i++) { 
			if (balones [i] != Vector3.zero)
				noVacio = true;
		}
		if(!noVacio){
			bolaCreada = false;
			Destroy(instanciaBola);
			print ("bola borrada");
		} else {
			Bola.GetComponent<movimientoBola>().setRuta (balones);
			print ("balon borrado");
		}

	}

	public void actualizarPosicion(int posicion, Vector3 coordenadas){
		if (posicion != -1) {
			balones [posicion] = coordenadas; 
			Bola.GetComponent<movimientoBola>().setRuta (balones);
		}
	}
	public void crearRedbull(Vector3 posicion)
    {
		redbull = posicion;
		if(instanciaBola != null)
			instanciaBola.GetComponent<movimientoBola>().setRedbull(posicion);
    }
	public void borrarRedbull()
	{
		redbull = Vector3.zero;
		Bola.GetComponent<movimientoBola>().setRedbull(Vector3.zero);
	}

}
