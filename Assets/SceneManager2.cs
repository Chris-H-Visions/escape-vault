using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour {

    public bool doorOpened = false;
    public bool dropCeiling = false;
    public string doorCode;
    public bool gameOver = false;
    public bool gameWin = false;
    public int gameSeconds;
    private int timeElapsed = 0;
    private int timeRemaining;
    public GameObject keyPad;
    public GameObject gameEnd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeElapsed = (int)Time.timeSinceLevelLoad;
        timeRemaining = gameSeconds - timeElapsed;
        //Debug.Log("GS:" + gameSeconds + "TE:" + timeElapsed);
        //Debug.Log("Time remaining:" +  timeRemaining);

        if (gameSeconds == timeElapsed && gameWin == false)
        {
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Time's UP!");
            RestartScene();
        }

	}

        public void RestartScene()
        {
            Debug.Log("GS:" + gameSeconds + "TE:" + timeElapsed);
            Debug.Log("Time remaining:" + timeRemaining);
            //doorOpened = false;
            //dropCeiling = false;
            //gameOver = false;
            keyPad.GetComponent<KeyPad>().ResetKeypad();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            //SceneManager.LoadScene("EscapeRoom");
        }
}
