using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Managers : MonoBehaviour
{
    private GameObject[] sceneMangeSceneObj; 

    static public SceneManagement sceneManager;
    static public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        sceneManager = sceneMangeSceneObj[0].GetComponent<SceneManagement>();
        gameManager = sceneMangeSceneObj[1].GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
