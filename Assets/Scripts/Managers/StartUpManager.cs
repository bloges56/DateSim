using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpManager : MonoBehaviour
{
    public string SceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(SceneToLoad,LoadSceneMode.Additive);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
