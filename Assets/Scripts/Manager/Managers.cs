using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Managers : MonoBehaviour
{
    private GameObject[] sceneMangeSceneObj; 

    static public SceneManagement sceneManager;
    static public GameManager gameManager;
    static public DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        sceneManager = sceneMangeSceneObj[0].GetComponent<SceneManagement>();
        gameManager = sceneMangeSceneObj[1].GetComponent<GameManager>();
        dialogueManager = sceneMangeSceneObj[2].GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
