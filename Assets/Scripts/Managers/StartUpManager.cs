using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpManager : MonoBehaviour
{
    public string SceneToLoad;
    public bool Started;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(SceneToLoad,LoadSceneMode.Additive);
        
    }

    public void start_scene()
    {
        Started = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
