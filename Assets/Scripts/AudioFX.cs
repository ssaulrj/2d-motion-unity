using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour {
	public AudioClip[] fxs;
	AudioSource audioS;
	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource> ();
	}

	public void FXSonidoChoque(){
		audioS.clip = fxs [0];
		audioS.Play ();
	}

	// Update is called once per frame
	public void FXMusic () {
		audioS.clip = fxs [1];
		audioS.Play ();
	}
}
