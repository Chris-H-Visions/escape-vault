using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public GameObject cameraLight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOn(){
        cameraLight.SetActive(true);

    }

    public void PickUp()
    {
        cameraLight.SetActive(true);
        gameObject.SetActive(false);
        TurnOn();
    }
}
