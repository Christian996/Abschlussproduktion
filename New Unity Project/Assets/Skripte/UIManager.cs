using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Button bt_Pause;

    void Awake()
    {
        bt_Pause = GetComponentInChildren<Button>();
        if(bt_Pause != null)
            Debug.Log("Pausebutton found: " + bt_Pause.name);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
}
