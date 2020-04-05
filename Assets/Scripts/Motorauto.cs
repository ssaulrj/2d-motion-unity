using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motorauto : MonoBehaviour {
	public GameObject autoGo;
	public float anguloGiro; 
	public float velocidad;
	//
	void Start () {
		autoGo = GameObject.FindObjectOfType<Auto> ().gameObject; //G clase, g objeto
	}
	
	//
	void Update () {
		float giroZ = 0;
		transform.Translate(Vector2.right*Input.GetAxis("Horizontal")*velocidad*Time.deltaTime); //velocidad con timedeltatime se acostumbra trabajar junto
		giroZ = Input.GetAxis("Horizontal") * -anguloGiro;
		autoGo.transform.rotation = Quaternion.Euler(0,0,giroZ); //Giro delicado
	}
}
