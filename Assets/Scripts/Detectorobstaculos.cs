using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detectorobstaculos : MonoBehaviour {
	public GameObject audioFX;
	public AudioFX audioScript;
	public GameObject cronometro;
	public Cronometro cronometroScript;

	// Inicializa objetos 
	void Start () {
		cronometro = GameObject.FindObjectOfType<Cronometro> ().gameObject;
		cronometroScript = cronometro.GetComponent<Cronometro> ();
		audioFX = GameObject.FindObjectOfType<AudioFX> ().gameObject;
		audioScript = audioFX.GetComponent<AudioFX> ();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.GetComponent<Auto>()!=null){
			audioScript.FXSonidoChoque ();
			cronometroScript.tiempo = cronometroScript.tiempo - 10; //tiempo de penalizar (10 seg)
			Destroy(this.gameObject);
		}
	}
}
