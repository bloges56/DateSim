using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitialize : MonoBehaviour
{
    private GameObject[] sceneMangeSceneObj; 

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(gameObject.scene);
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        if(sceneMangeSceneObj.Length == 0)
        {
            Debug.LogError("Unable to locate scene.");
        }
    }
}
