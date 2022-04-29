using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    private Button startButton;
    private Button quitButton;

    [SerializeField] GameObject startBut;
    [SerializeField] GameObject endBut;

    public bool OverrideStart = false;
    public string OverrideSceneName;

    SceneManagement sceneManager;
    GameManager gameManager;

    void Start()
    {
        startButton =startBut.GetComponent<Button>();
        quitButton = endBut.GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(EndGame);

        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
    }


    public void StartGame()
     {
         sceneManager.StartSceneLoad("SetName");
        // if(OverrideStart)
        // {
        //     sceneManager.StartSceneLoad(OverrideSceneName);
        // }
        // else
        // {
        // sceneManager.StartSceneLoad("GrayBoxMain");
        // }
        gameManager.LoadGame();

     }

     void EndGame()
     {
        Debug.Log("Ending Game...");
        Application.Quit();

     }
}
