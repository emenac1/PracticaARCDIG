using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoBola : MonoBehaviour {
	public Rigidbody rb;
	public Vector3[] ruta;
	public float velocidadVertical;
	public int actual;
	public bool botado;
	// Use this for initialization

	public static movimientoBola bola;

	void Awake(){
		bola = this;
	}

	void Start () {
		print ("bola creada");
		rb = GetComponent<Rigidbody> ();
		ruta = new Vector3[5];
		for (int i = 0; i < 5; i++) {
			ruta [i] = Vector3.zero;
		}
		velocidadVertical = 40;
		actual = 0;
		botado = false;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y <= 0) {
			velocidadVertical = 40;
			if (!botado) {
				botado = true;
				rb.velocity = new Vector3 (0, velocidadVertical, 0);
			} else {
				
				int siguiente = 0;
				for (int i = actual+1; i < actual+6; i++) {
					if (ruta [i % 5] != Vector3.zero) {
						siguiente = i%5;
					}
				}

				float velocidadX=(ruta[siguiente].x-ruta[actual].x)*20;
				float velocidadZ=(ruta[siguiente].z-ruta[actual].z)*20;
				actual = siguiente;
				rb.velocity = new Vector3 (velocidadX, velocidadVertical, velocidadZ);
				botado = false;
			}
		}

		
	}
	public void setRuta(Vector3[] ruta){
		this.ruta = ruta;
	}
}
