using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour {

    private string correctCode = "";
    public static string playerCode = "";
    public static int totalDigits=0;
    public Text displayText;
    public GameObject door;
    public GameObject ceiling;
    public GameObject restartMenu;
    private Animator anim;

	// Use this for initialization
	void Start () {
		//ResetKeypad();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnKeyClick()
    {
        
        correctCode = Manager.Instance.doorCode;
        playerCode += gameObject.name;
        displayText.text = playerCode;
        totalDigits += 1;

        //Debug.Log("Digits: " + totalDigits);
        //Debug.Log("Code: " + playerCode);

        if (totalDigits == 4)
        {
            if (playerCode == correctCode)
            {
                playerCode = "";
                totalDigits = 0;
                //Debug.Log("Correct");
                displayText.text = "Get out!";
                anim = door.GetComponent<Animator>();
                anim.Play("doorAnimation");
                restartMenu.SetActive(true);
                Manager.Instance.gameWin = true;
            }
            else
            {
                //Manager.Instance.playerCode = "";
                playerCode = "";
                totalDigits = 0;
                ceiling.GetComponent<CeilingController>().DropCeiling();
                //CeilingController.In
                //Manager.Instance.dropCeiling = true;
                displayText.text = "Invalid!";
            }


        }
    }

    public void ResetKeypad(){

        totalDigits = 0;
        playerCode = "";

    }
}
