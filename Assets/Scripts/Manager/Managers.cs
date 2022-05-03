using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Managers : MonoBehaviour
{
    private static GameObject[] sceneMangeSceneObj; 

    public static SceneManagement sceneManager;
    public static GameManager gameManager;
    public static DialogueManager dialogueManager;

    
    // Start is called before the first frame update
    void Awake()
    {
        // sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        // if(sceneMangeSceneObj.Length == 0)
        // {
        //     Debug.LogError("Unable to locate scene.");
        // }
        // sceneManager = sceneMangeSceneObj[0].GetComponent<SceneManagement>();
        // gameManager = sceneMangeSceneObj[1].GetComponent<GameManager>();
        // dialogueManager = sceneMangeSceneObj[2].GetComponent<DialogueManager>();

        sceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManagement>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        dialogueManager = GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>();

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

        if(dialogueManager){
            Debug.Log("Found dialgue manager");
        }
        else{
            Debug.LogError("Faiedl to find dialogue manage");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(sceneManager == null || gameManager == null || dialogueManager == null )
        {
            sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
            if(sceneMangeSceneObj.Length == 0)
            {
                Debug.LogError("Unable to locate scene.");
            }
            sceneManager = sceneMangeSceneObj[0].GetComponent<SceneManagement>();
            gameManager = sceneMangeSceneObj[1].GetComponent<GameManager>();
            dialogueManager = sceneMangeSceneObj[2].GetComponent<DialogueManager>();
        }
        
        int countLoaded = SceneManager.sceneCount;
        Debug.Log(countLoaded);
    }

    public static GameManager GetGameManager()
    {
        return sceneMangeSceneObj[1].GetComponent<GameManager>();
    }

    public static SceneManagement GetSceneManager()
    {
        return sceneMangeSceneObj[0].GetComponent<SceneManagement>();
    }
}
