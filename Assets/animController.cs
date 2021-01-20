using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {

    public bool doorOpening;

    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       if(doorOpening){
            OpenDoor();
        }
	}

    void OpenDoor(){
        anim.Play("doorAnimation");
    }
}
