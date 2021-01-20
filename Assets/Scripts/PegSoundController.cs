using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegSoundController : MonoBehaviour {
    public AudioClip pegCrash;
    //public GameObject peg;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().clip = pegCrash;
	}
	
    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        gameObject.GetComponent<AudioSource>().Play();
        Debug.Log("Peg Collision");
        Debug.Log(gameObject.name);
    }

}