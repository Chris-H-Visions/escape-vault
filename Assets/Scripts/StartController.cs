using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {

    public GameObject blindFold;
    public GameObject rightEar;
    public GameObject leftEar;
    public AudioClip getOut;
    public AudioClip badThing;

    private bool getOutHasPlayed;
    private bool badThingHasPlayed;

	// Use this for initialization
	void Start () {
        rightEar.GetComponent<AudioSource>().playOnAwake = false;
        leftEar.GetComponent<AudioSource>().playOnAwake = false;

        rightEar.GetComponent<AudioSource>().clip = badThing;

        rightEar.GetComponent<AudioSource>().Play();
        badThingHasPlayed = true;

	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(rightEar.GetComponent<AudioSource>().isPlaying);
        if(!rightEar.GetComponent<AudioSource>().isPlaying){
            if(!getOutHasPlayed){
                leftEar.GetComponent<AudioSource>().clip = getOut;
                leftEar.GetComponent<AudioSource>().Play();
                getOutHasPlayed = true;
                blindFold.SetActive(false);
            }
           

        }
	}
}
