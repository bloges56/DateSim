using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneAdd(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        // SceneManager.LoadScene(SceneName,LoadSceneMode.Additive);
    }

    public void LoadUnLoadSceneAdd(string SceneName)
    {

        // string activeScene = SceneManager.GetActiveScene().name;
        string activeScene = "HomeScreen";
        SceneManager.UnloadSceneAsync(activeScene);
        SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Additive);


        // string activeScene = SceneManager.GetActiveScene().name;
        // string activeScene = "HomeScreen";
        // SceneManager.LoadScene("LoadingScene");
        // SceneManager.UnloadSceneAsync(activeScene);
        // SceneManager.UnloadSceneAsync("LoadingScene");

        // SceneManager.LoadScene(SceneName);

        // SceneManager.LoadScene(SceneName,LoadSceneMode.Additive);
    }
    public void LoadUn(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Additive);
    }
}
