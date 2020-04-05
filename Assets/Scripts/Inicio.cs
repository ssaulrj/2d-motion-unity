using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour {
	public GameObject motorCalles;
	public Motorcalles motorCallesScript;
	public Sprite[] numeros;

	public GameObject contadorNumeros;
	public SpriteRenderer contadorNumerosComponente;

	public GameObject controlAuto;
	public GameObject auto;
	// Use this for initialization
	void Start () {
		iniciarComponentes ();
	}
	void iniciarComponentes(){
		motorCalles = GameObject.Find ("Motorcalles");
		motorCallesScript = motorCalles.GetComponent<Motorcalles> ();
		contadorNumeros = GameObject.Find ("Contador");
		contadorNumerosComponente = contadorNumeros.GetComponent<SpriteRenderer> ();
		auto = GameObject.Find ("Auto");
		controlAuto = GameObject.Find ("ControlAuto");
		iniciarContador ();
	}
	void iniciarContador(){
		
		StartCoroutine (Contando());
	}
	IEnumerator Contando(){
		controlAuto.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds (2);
		contadorNumerosComponente.sprite = numeros[1];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);
		Debug.Log (contadorNumerosComponente.sprite.ToString());
		contadorNumerosComponente.sprite = numeros[2];
		this.gameObject.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		contadorNumerosComponente.sprite = numeros[3];
		motorCallesScript.inicioJuego = true;
		contadorNumeros.GetComponent<AudioSource>().Play();
		auto.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2);

		contadorNumeros.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
