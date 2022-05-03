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
    private static GameObject[] sceneMangeSceneObj; 


    void Start()
    {
        startButton = GameObject.Find("Start-Button").GetComponent<Button>();
        quitButton = GameObject.Find("Exit-Button").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(EndGame);
        // if(loaded)
        // SceneManager.LoadSceneAsync("SceneManagerScene",LoadSceneMode.Additive);



        // sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        // if(sceneMangeSceneObj.Length < 1 || sceneMangeSceneObj == null)
        // {
        //     Debug.LogError("Unable to locate scene.");
        // }
        // sceneManager = sceneMangeSceneObj[0].gameObject.GetComponent<SceneManagement>();
        // gameManager = sceneMangeSceneObj[1].gameObject.GetComponent<GameManager>();


        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        
        if(sceneManager){
            Debug.Log("Found scene manager");
        }
        else{
            Debug.LogError("Faiedl to find scene manage");
        }

        if(gameManager){
            Debug.Log("Found game manager");
        }
        else{
            Debug.LogError("Faiedl to find game manage");
        }
        // SceneManager.SetActiveScene(gameObject.scene);


    }
    private void Update() {
        // if(sceneManager == null || gameManager == null )
        // {
        //     sceneManager = Managers.sceneManager;
        //     gameManager = Managers.gameManager;
        // }

        // int countLoaded = SceneManager.sceneCount;
        // Debug.Log(countLoaded);
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
        Managers.sceneManager.StartSceneLoad("GrayBoxMain");
        }
        Managers.gameManager.LoadGame();

     }

     void EndGame()
     {
        Debug.Log("Ending Game...");
        Application.Quit();

     }
}
