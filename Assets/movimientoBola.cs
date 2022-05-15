using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoBola : MonoBehaviour {
	public Rigidbody rb;
	public Vector3[] ruta;
	public float velocidadVertical;
	public int actual;
	public bool botado;
	private int siguiente;
	private int cont;
	private bool finalizado;
	private Vector3 redbull;


	// Use this for initialization

	public void Awake()
	{
		finalizado = false;
		ruta = new Vector3[4];
		for (int i = 0; i < 4; i++)
			ruta[i] = Vector3.zero; 
		
	}

	void Start () {
		print ("bola creada");
		rb = GetComponent<Rigidbody> ();
		ruta = new Vector3[4];
		for (int i = 0; i < 4; i++) {
			ruta [i] = Vector3.zero;
		}
		velocidadVertical = 2000;
		actual = 0;
		botado = false;
		siguiente = 0;
		cont = 200;
		finalizado = false;
		redbull = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {


		if (transform.position.y <= 0 && cont < 0)
		{
			if (finalizado)
			{
				rb.velocity = new Vector3(0, 0, 0);
			}
			else
			{
				cont = 200;
				rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
				rb.AddForce(transform.up * velocidadVertical);

				//transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);


				if (!botado)
				{
					botado = true;
					print("No paraboleo y pongo botado a true");
					rb.velocity = new Vector3(0, rb.velocity.y, 0);
				}
				else
				{

					bool encontrado = false;
					for (int i = actual + 1; i < actual + 5 && !encontrado; i++)
					{
						if (ruta[i % 4] != Vector3.zero)
						{
							siguiente = i % 4;
							encontrado = true;
						}

					}
					print("Actual=" + actual + "Siguiente=" + siguiente);
					if (actual != siguiente)
					{
						bool noVacio = true;
						if (siguiente == 0)
						{
							print ("el siguiente 0");
							
							for (int i = 0; i < 4 && noVacio; i++)
							{
								if (ruta[i] == Vector3.zero)
									noVacio = false;
								print (ruta [i]);
							}
							print ("no vacio vale: " + noVacio);
							if (noVacio)
							{
								siguiente = 4;

								print ("good ending");
							}

						}
						if (siguiente != 4) {
							print ("Paraboleo y pongo botado a false");
							botado = false;
							print ("estoy en ruta de actual " + ruta [actual]);
							print ("estoy en ruta de siguiente " + ruta [siguiente]);

							rb.AddForce ((ruta [siguiente].x - ruta [actual].x) * 6, 0, (ruta [siguiente].z - ruta [actual].z) * 6);

							actual = siguiente;
						} else {
							print ("Voy al RedBull");
							botado = true;
							print ("estoy en ruta de actual " + ruta [actual]);
							print ("estoy en ruta de siguiente " + redbull);

							rb.AddForce ((redbull.x - ruta [actual].x) * 6, 0, (redbull.z - ruta [actual].z) * 6);
							finalizado = true;
						}

					}
				}
				
			}
		
		}
		cont--;



	}
	public void setRuta(Vector3[] balones){
		for(int i=0; i<4; i++)
        {
			Vector3 aux = new Vector3( balones[i].x,balones[i].y,balones[i].z);
			ruta[i] = aux;
        }
		
		print ("esta es la ruta: ");
		for (int i = 0; i < 4; i++)
			print (ruta [i]);
	}
	public void setRedbull(Vector3 posicion)
	{
		redbull = posicion;
		print ("RedBull encontrado" + redbull);
	}



}
