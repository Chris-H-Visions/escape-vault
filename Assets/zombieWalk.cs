using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieWalk : MonoBehaviour {
    public float speed;
    public bool attack;
    public bool backFall;
    public bool rightFall;

    protected Animator myAnimation;
	// Use this for initialization

    void Start () {
        myAnimation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//myAnimation.SetFloat("speed", Input.GetAxis("Vertical"));
        myAnimation.SetFloat("speed", speed);
        myAnimation.SetBool("attack", attack);
        myAnimation.SetBool("backFall", backFall);
        myAnimation.SetBool("rightFall", rightFall);
	}
}
