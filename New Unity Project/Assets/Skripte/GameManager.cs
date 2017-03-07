using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// Script is belonging to the Object with the UI Tag - or Objectname Canvas
// this Script will handle, if the Game has to be Paused or not and the gametime
public class GameManager : MonoBehaviour
{
    // Timeline
    Image im_ZeitleisteVoll;
    float startTime = 180;
    float remainingGameTimeInSec;
    float elapsedTime = 0f;
    // Pausemenue
    GameObject pauseMenue;
    bool isPaused;

    void Awake()
    {
        im_ZeitleisteVoll = GameObject.Find("ZeitleisteVoll").GetComponent<Image>();
        pauseMenue = GameObject.Find("PauseMenü");
    }
    // Use this for initialization
    void Start()
    {
        isPaused = false;
        pauseMenue.SetActive(false);
        // Set remaining time to Starttime at the beginning
        remainingGameTimeInSec = startTime;
        im_ZeitleisteVoll.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        ReduceGameTime();
        ReduceTimeLine

    }

    void float GetRemainingTime()
    {
        remainingGameTimeInSec -= Time.deltaTime;
    }
    void float GetElapsedTime()
    {
        return elapsedTime += Time.deltaTime;
    }

    void ReduceTimeLine(float p_elapsedGameTime)
    {
        float percentTime = (p_elapsedGameTime / startTime);
        im_ZeitleisteVoll.fillAmount -= percentTime;
    }


    // Will be called from the InputManager
    // it will check for the Tag and Name and call corresponding Functions

    // Need Tag:"Button" and Name "PauseCollider" or "ContinueCollider"
    public void ChangeGamestate()
    {
        if (!isPaused)
        {
            Debug.Log("Game paused");
            Time.timeScale = 0;
            pauseMenue.SetActive(true);
            AudioListener.pause = true;
            isPaused = true;
        }
        else
        {
            Debug.Log("Game unpaused");
            pauseMenue.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
            isPaused = false;
        }
    }

    // Need Name "QuietCollider"
    public void ExitGame()
    {
        Application.Quit();
    }


}
