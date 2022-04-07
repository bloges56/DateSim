using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    SceneManagement sceneManager;
    GameManager gameManager;
    // Start is called before the first frame update
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
        sceneManager.StartSceneLoad("GrayBoxMain");
        gameManager.LoadGame();
     }
     
     void EndGame()
     {
         Debug.Log("Ending Game...");
     }
}
