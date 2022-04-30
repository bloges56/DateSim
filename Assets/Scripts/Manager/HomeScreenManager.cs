using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HomeScreenManager : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    public bool OverrideStart = false;
    public string OverrideSceneName;

    private bool loaded = false;
    SceneManagement sceneManager;
    GameManager gameManager;

    void Start()
    {
        startButton = GameObject.Find("Start-Button").GetComponent<Button>();
        quitButton = GameObject.Find("Exit-Button").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(EndGame);
        // if(loaded)
        // SceneManager.LoadSceneAsync("SceneManagerScene",LoadSceneMode.Additive);

        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        // SceneManager.SetActiveScene(gameObject.scene);


    }
    private void Update() {
        if(sceneManager == null || gameManager == null )
        {
            sceneManager = Managers.sceneManager;
            gameManager = Managers.gameManager;
        }
        int countLoaded = SceneManager.sceneCount;
        Debug.Log(countLoaded);
        // SceneManager.SetActiveScene(gameObject.scene);

        // Debug.WriteLine(countLoaded);
    }

    void StartGame()
     {
        if(OverrideStart)
        {
            sceneManager.StartSceneLoad(OverrideSceneName);
        }
        else
        {
        sceneManager.StartSceneLoad("GrayBoxMain");
        }
        gameManager.LoadGame();

     }

     void EndGame()
     {
        Debug.Log("Ending Game...");
        Application.Quit();

     }
}
