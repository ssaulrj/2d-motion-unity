using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorcalles : MonoBehaviour {

	public float velocidad;
	public bool inicioJuego;
	public bool juegoTerminado;
	public GameObject contenedorCalles;
	public GameObject[] contenedorCallesArreglo;
	// Use this for initialization
	int contadorCalles=0;
	int numeroCalleSeleccionada=0;
	public GameObject calleAnterior;
	public GameObject calleNueva;
	public float longitudCalle;
	public Vector3 medidaLimitePantalla; //magnitud de la pantalla
	public bool salioDePantalla; // bandera
	public GameObject mCamara; //controlan la camara estoss objetos
	public Camera mCamaraComp; //clase camera 

	void Start () {
		iniciarJuego ();
		
	}

	void iniciarJuego(){
		contenedorCalles = GameObject.Find ("contenedorCalles");
		mCamara = GameObject.Find ("Main Camera");
		mCamaraComp = mCamara.GetComponent<Camera> ();
		velocidadMotorCalles ();
		buscarCalles ();
	}

	void buscarCalles(){
		contenedorCallesArreglo = GameObject.FindGameObjectsWithTag ("Calle");

		for (int i = 0; i < contenedorCallesArreglo.Length; i++) {
				//Debug.Log (contenedorCallesArreglo.Length);
				//Los objetos con el Tag calle se hacen hijos del objeto
				contenedorCallesArreglo [i].gameObject.transform.parent = contenedorCalles.transform;
				//Se desactivan las calles
				contenedorCallesArreglo [i].gameObject.SetActive (false);
				//Se le asigna nuevo nombre a la calle
				contenedorCallesArreglo [i].gameObject.name = "CalleOFF_" + i;
		}
		crearCalle ();
	}

	void crearCalle(){
		contadorCalles++;
		numeroCalleSeleccionada = Random.Range (0,contenedorCallesArreglo.Length);
		GameObject Calle = Instantiate (contenedorCallesArreglo[numeroCalleSeleccionada]); //calle clonada nueva!
		Calle.SetActive(true); //activar calle seleccionada
		Calle.name = "Calle" + contadorCalles; //contador cuantas calles lleva
		Calle.transform.parent = gameObject.transform; //papá de esta calle sera el motorcalle, Hereda
		posicionarCalle();
	}

	void posicionarCalle(){
		calleAnterior =GameObject.Find("Calle"+(contadorCalles-1));
		calleNueva = GameObject.Find ("Calle"+contadorCalles);
		medirCalle ();
		calleNueva.transform.position = new Vector3 (calleAnterior.transform.position.x, calleAnterior.transform.position.y + longitudCalle, 0); 
		salioDePantalla = false;
	}

	void medirCalle(){
		for(int i= 0; i < calleAnterior.transform.childCount; i++ ){ //calle... cuantas piezas tiene 
			if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<Pieza>() != null){ //contar los que si son piezas de la calle. child(i) se situa en objeto, gameObject que tenga como  componente al script
				float longitudPieza= calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y; //altitud de pieza
				longitudCalle = longitudCalle + longitudPieza;
			}
		}
	}

	void velocidadMotorCalles(){
		velocidad=18;
	}
	// Medir la longitud de la pantalla
	void medirPantalla(){
		medidaLimitePantalla = new Vector3 (0,mCamaraComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f ,0); //.5 hace traslapar las calles
		
	}
	// Update is called once per frame
	void Update () {
		if (inicioJuego == true && juegoTerminado == false) {
			transform.Translate(Vector3.down*velocidad*Time.deltaTime); //siempre usemos velocidades
			if (calleAnterior.transform.position.y + longitudCalle < medidaLimitePantalla.y && salioDePantalla == false) {
				salioDePantalla = true;
				destruirCalle ();
			}
		}

	}

	void destruirCalle(){
		Destroy (calleAnterior);
		longitudCalle = 0;
		calleAnterior = null;
		crearCalle ();
	}

}
