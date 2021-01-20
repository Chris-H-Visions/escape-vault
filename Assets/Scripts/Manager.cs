using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager Instance { get; private set; }

    //public bool gameUnlocked;
    public bool doorOpened = false;
    public bool dropCeiling = false;
    public string doorCode;
    public bool gameOver = false;
    public bool gameWin = false;
    public int gameSeconds;
    private int timeElapsed = 0;
    private int timeRemaining;
    public GameObject keyPad;
    public GameObject timesUpMenu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        timeElapsed = (int)Time.timeSinceLevelLoad;
        timeRemaining = gameSeconds - timeElapsed;
        //Debug.Log("GS:" + gameSeconds + "TE:" + timeElapsed);
        //Debug.Log("Time remaining:" +  timeRemaining);

        if(gameSeconds == timeElapsed && gameWin == false){
            //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Time's UP!");
            timesUpMenu.SetActive(true);
            //RestartGame();
        }

        //restart game if time expires
        if (gameSeconds+10 == timeElapsed && gameWin == false)
        {
            RestartGame();
        }

        //restart game if player makes mistake and another script sets gameOver
        if (gameOver)
        {
            RestartGame();
        }

        /*if(gameWin == true){
            Debug.Log("You Escaped!!");
        }*/
    }

    public void RestartGame()
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


