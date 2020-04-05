using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour {
	public GameObject motorCalles;
	public Motorcalles motorCallesScript;
	public float tiempo;
	public float distancia;
	public Text  txtTiempo; //variables que pintann  
	public Text  txtDistancia;
	public Text  txtDistanciaFinal;
	// 
	void Start () {
		motorCalles = GameObject.Find("Motorcalles");
		motorCallesScript = motorCalles.GetComponent<Motorcalles> ();
		txtTiempo.text= "2:00"; //4 minutos 240 en tiempo
		txtDistancia.text = "0";
		tiempo = 120;

	}
	// 
	void Update () {
		if (motorCallesScript.inicioJuego==true && motorCallesScript.juegoTerminado==false) {
			CalculoTiempoDistancia ();
		}
	}
	void CalculoTiempoDistancia(){
		distancia += Time.deltaTime * motorCallesScript.velocidad;
		txtDistancia.text = ((int)distancia).ToString ();
		tiempo -= Time.deltaTime;
		int minutos = (int)tiempo / 60;
		int segundos = (int)tiempo % 60; //residuo
				txtTiempo.text = minutos.ToString () + ":" + segundos.ToString().PadLeft(2,'0'); //padleft relllenar a la izquierda
	}
}
