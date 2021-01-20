using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour {

    public bool useDropInterval;
    public int secondsBetweenDrops;
    private int secondsSinceLastDrop;
    private int secondsAtLastDrop;
    //public bool dropCeiling;
    //public int stage;
    public GameObject[] stages;

    private GameObject PegsStage1;
    private GameObject PegsStage2;
    private GameObject PegsStage3;
    private GameObject PegsStage4;
    private GameObject PegsStage5;

    public GameObject ceiling;
    private GameObject pegNorth;
    private GameObject pegSouth;
    private GameObject pegEast;
    private GameObject pegWest;
    public float pegSpeed;

    private GameObject currentStage;
    private int stageCount;
    private int totalStages = 5;
    private int timeElapsed;

    private AudioSource audioSource;
    public AudioClip pegMoving;
    //public AudioClip floorCrash;




	// Use this for initialization
	void Start () {
        //start at stage 0
        stageCount = 0;


        foreach (GameObject stage in stages)
        {
            if(stage.name == "PegsStage0")
            {
                PegsStage1 = stage;
            }
            if (stage.name == "PegsStage1")
            {
                PegsStage2 = stage;
            }

            if (stage.name == "PegsStage2")
            {
                PegsStage3 = stage;
            }

            if (stage.name == "PegsStage3")
            {
                PegsStage4 = stage;
            }

            if (stage.name == "PegsStage4")
            {
                PegsStage5 = stage;
            }
        }
        //GetComponent<GvrAudioSource>().playOnAwake = false;
        //GetComponent<GvrAudioSource>().clip = pegCrash;
	}
	
	// Update is called once per frame
	void Update () {

        //dropCeiling = Manager.Instance.dropCeiling;
        if(useDropInterval){
            timeElapsed = (int)Time.timeSinceLevelLoad;
            secondsSinceLastDrop = timeElapsed - secondsAtLastDrop;

            //Debug.Log(secondsBetweenDrops + " : " + timeElapsed + " : " +  secondsAtLastDrop);

            if(secondsBetweenDrops == secondsSinceLastDrop){
                Manager.Instance.dropCeiling = true;
            }else{
                Manager.Instance.dropCeiling = false;
            }
        }

        if(stageCount == 0){
            currentStage = PegsStage1;
        }
        if (stageCount == 1)
        {
            currentStage = PegsStage2;
            //Debug.Log("PegStage: " + currentStage.name);
        }

        if (stageCount == 2)
        {
            currentStage = PegsStage3;
           // Debug.Log("PegStage: " + currentStage.name);
        }

        if (stageCount == 3)
        {
            currentStage = PegsStage4;
            // Debug.Log("PegStage: " + currentStage.name);
        }

        if (stageCount == 4)
        {
            currentStage = PegsStage5;
            // Debug.Log("PegStage: " + currentStage.name);
        }

        //assign each peg
        foreach (Transform child in currentStage.transform)
        {
            if(child.name == "PegWest"){
                pegWest = child.gameObject;
            }
            if (child.name == "PegNorth")
            {
                pegNorth = child.gameObject;
            }
            if (child.name == "PegSouth")
            {
                pegSouth = child.gameObject;
            }
            if (child.name == "PegEast")
            {
                pegEast = child.gameObject;
            }
        }

        if(Manager.Instance.dropCeiling){
            // Use this for initialization
            audioSource = gameObject.GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                pegNorth.transform.position = new Vector3(pegNorth.transform.position.x, pegNorth.transform.position.y, pegNorth.transform.position.z + pegSpeed);
                pegSouth.transform.position = new Vector3(pegSouth.transform.position.x, pegSouth.transform.position.y, pegSouth.transform.position.z - pegSpeed);
                pegEast.transform.position = new Vector3(pegEast.transform.position.x + pegSpeed, pegEast.transform.position.y, pegEast.transform.position.z);
                pegWest.transform.position = new Vector3(pegWest.transform.position.x - pegSpeed, pegWest.transform.position.y, pegWest.transform.position.z);
                secondsAtLastDrop = timeElapsed;
                stageCount++;
                //make sure the ceiling only drops one stage unless we want it to
                Manager.Instance.dropCeiling = false;
                //Debug.Log("PegStage: " + currentStage.name);

                if(stageCount == totalStages){
                    Manager.Instance.gameOver = true; 
                };
            }

            

        }
        //Debug.Log("StageCount: " + stageCount);




	}

        void OnCollisionEnter()  //Plays Sound Whenever collision detected
        {
        //GetComponent<GvrAudioSource>().Play();
        }

    public void DropCeiling(){
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = pegMoving;
        audioSource.Play();
        Manager.Instance.dropCeiling = true;

    }
}
