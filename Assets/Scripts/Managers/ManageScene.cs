using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    public Canvas score;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.Find("Canvas");
        if(temp != null){
            Debug.Log("Found the gameobject");
            score = temp.gameObject.GetComponent<Canvas>();
            if(score == null)
            {
                Debug.Log("Did not find the canvas");
            }
        }
        else{
            Debug.Log("Couldn't find the scoreboard");
        }

        // score = temp.GetComponent<Canvas>();
    //    canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        // if()
        // while(Input.GetKey(KeyCode.Tab)){
        score.gameObject.SetActive(Input.GetKey(KeyCode.Tab));
            // Debug.Log("True");
        // }

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

    public void LoadUnScene(string LoadName, string ThisScene)
    {
        SceneManager.UnloadSceneAsync(ThisScene);
        SceneManager.LoadSceneAsync(LoadName, LoadSceneMode.Additive);

    }
    // public static void LoadUnScene(string LoadName, string ThisScene)
    // {
    //     SceneManager.UnloadSceneAsync(ThisScene);
    //     SceneManager.LoadSceneAsync(LoadName, LoadSceneMode.Additive);

    // }
    public void LoadUn(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Additive);
    }
}
