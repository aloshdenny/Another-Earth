using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public static bool gameStart = false;
    public GameObject hud,video,startScreen,controlScreen,player;
    public float time=48;
    public Text objective;
    //public VideoPlayer vidP;
    public GameObject intro;
    public GameObject prompt;
    public Text promptText;
    bool hudOn = false;
    bool controlOn = false;
    bool promptWait = false;
    bool promptWaitDone = false;
    public AudioSource ambient;
    public AudioClip ambience;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("GameStart",0);
        startScreen.SetActive(true);
        Movement.playerStationary1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) {
            PlayAudio.buttonPlay = true;
            Application.Quit();
        }
        if (promptWait && Input.GetKeyDown(KeyCode.Z))
        {
            print("pressedZ");
            PlayAudio.buttonPlay = true;
            promptWaitDone = true;
            promptWait = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)&&controlOn) { 
            controlScreen.SetActive(false);
            startScreen.SetActive(true);
            controlOn= false;
            PlayAudio.buttonPlay = true;
        }
    }
    public void Play() {
        PlayAudio.buttonPlay = true;
        if (PlayerPrefs.GetInt("GameStart", 0) == 0)
        {
            intro.SetActive(true);
            StartCoroutine(waitForVideo());
        }
        else
        {
            
            prompt.SetActive(false);
            Movement.playerStationary1 = false;
            hud.SetActive(true);
            
        }
        startScreen.SetActive(false);
        ambient.PlayOneShot(ambience);
    }

    public void control() {
        PlayAudio.buttonPlay = true;
        controlScreen.SetActive(true);
        startScreen.SetActive(false);
        controlOn= true;
    }

    public void newGame() {
        SpaceShipDeposit.gameReset=true;
        PlayerPrefs.SetInt("GameStart", 0);
        Play();
    }
    public void quit() {
        PlayAudio.buttonPlay = true;
        print("quitting");
        Time.timeScale = 1;
        Application.Quit();
    }
    
    IEnumerator waitForVideo() {
        yield return new WaitForSeconds(time);
        intro.SetActive(false);
        PlayerPrefs.SetInt("GameStart", 1);
        player.transform.position= Vector3.zero;
        
        prompt.SetActive(true);

        promptText.text = "Damn, the SpaceShip is busted(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "GEO-SCANNER : detected elements needed to repair SpaceShip in 3 nearby caves(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "GEO-SCANNER : detected elements needed to repair SpaceShip in 3 nearby caves(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "'Esc : view objective'(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        Movement.playerStationary1 = false;

        promptText.text = "'Arrow Keys : Move'(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "'Left Ctrl : Run'(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "'Alt : Attack/Break'(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        promptText.text = "'X : Cancel Choice'(Z)";
        promptWait = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => promptWaitDone == true);
        promptWaitDone = false;

        prompt.SetActive(false);

        objective.text = "Find element in the cave west of current location ";

        hud.SetActive(true);

    }
    
}

