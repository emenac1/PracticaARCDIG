using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoBola : MonoBehaviour {
	public Rigidbody rb;
	public Vector3[] ruta;
	public float velocidadVertical;
	public int actual;
	public bool botado;



	public float ShotSpeed; // Velocidad de lanzamiento
	private float time;
	public Transform pointA; // punto de partida
	public Transform pointB; // punto final
	public float g = -10; // aceleración de la gravedad
	private Vector3 speed; // vector de velocidad inicial
	private Vector3 Gravity; // vector de gravedad
	private Vector3 currentAngle; // ángulo actual

	private float dTime = 0;

	bool entro;

	private bool parabola;


	// Use this for initialization

	//public static movimientoBola bola;



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
		entro = true;
		ShotSpeed = 10;
		parabola = false;
	}

	// Update is called once per frame
	void Update () {
		if (parabola) {
			int siguiente = 0;
			bool encontrado = false;
			for (int i = actual + 1; i < actual + 6 && !encontrado; i++) {
				if (ruta [i % 5] != Vector3.zero) {
					siguiente = i % 5;
					encontrado = true;
				}

			}

			if (ruta [actual] == ruta [siguiente]) {
				parabola = false;
				botado = false;
				entro = true;
			}else {

				if (entro) {
					iniciarParabola (ruta [actual], ruta [siguiente]);
					entro = false;
				}

		
				// v=gt
				Gravity.y = g * (dTime += Time.fixedDeltaTime);
				// Desplazamiento analógico
				transform.position += (speed + Gravity) * Time.fixedDeltaTime;
				// Rotación en radianes: Mathf.Rad2Deg
				currentAngle.x = -Mathf.Atan ((speed.y + Gravity.y) / speed.z) * Mathf.Rad2Deg;
				// Establecer el ángulo actual
				transform.eulerAngles = currentAngle;



				print ("estoy en ruta de actual " + ruta [actual]);
				print ("estoy en ruta de siguiente " + ruta [siguiente]);


				if (transform.position.y <= ruta[siguiente].y) {
					transform.position = ruta[siguiente];
					actual = siguiente;
					botado = false;
					parabola = false;
					entro = true;
					transform.eulerAngles = Vector3.zero;
					//transform.position = new Vector3 (transform.position.x, 0.1f, transform.position.z);
				}
			}
		} else {
			if (transform.position.y <= ruta[actual].y) {
				velocidadVertical = 2000;
				if (!botado) {
					botado = true;
					rb.AddForce (transform.up*velocidadVertical);
				} else {
					parabola = true;
				}
				//transform.position = new Vector3 (transform.position.x, 0.1f, transform.position.z);
			}
		}



		
	}
	public void setRuta(Vector3[] ruta){
		this.ruta = ruta;
		print ("esta es la ruta: ");
		for (int i = 0; i < 5; i++)
			print (ruta [i]);
	}

	public void destruir(){
		Destroy (this.gameObject);
	}

	public void iniciarParabola(Vector3 posicionA, Vector3 posicionB){
		// tiempo = distancia / velocidad

		time = Vector3.Distance(posicionA, posicionB)/ShotSpeed;

		// Establece la posición del punto de inicio en A
		transform.position = posicionA;

		// Calcula la velocidad inicial mediante una ecuación

		speed = new Vector3((posicionB.x - posicionA.x) / time,
			(posicionB.y - posicionA.y) / time - 0.5f * g * time, (posicionB.z - posicionA.z) / time);


		// La velocidad inicial de la gravedad es 0

		Gravity = Vector3.zero;

	}
		

}
