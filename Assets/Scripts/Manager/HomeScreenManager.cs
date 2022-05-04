using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HomeScreenManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private bool loaded = false;
    
    SceneManagement sceneManager;
    GameManager gameManager;


    void Start()
    {
        startButton = GameObject.Find("Start-Button").GetComponent<Button>();
        quitButton = GameObject.Find("Exit-Button").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(EndGame);
       
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        
    }

    void StartGame()
     {
        sceneManager.StartSceneLoad("SetName");
        Managers.gameManager.LoadGame();

     }

     void EndGame()
     {
        Debug.Log("Ending Game...");
        Application.Quit();

     }
}
