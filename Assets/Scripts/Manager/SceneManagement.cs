using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public Canvas scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.Find("Canvas");
        if(temp!=null)
        {
            scoreBoard = temp.gameObject.GetComponent<Canvas>();
        }
        else{
            Debug.LogError("Couldn't find the scoreboard!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.gameObject.SetActive(Input.GetKey(KeyCode.Tab));
    }

    public void SingleLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        StartCoroutine(LoadSceneCoRou(sceneToLoadName));
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoadName));

    }

    IEnumerator LoadSceneCoRou(string SceneToLoad)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(SceneToLoad,LoadSceneMode.Additive);
        loadingScene.allowSceneActivation = false;

        while(loadingScene.progress < 0.85f)
        {
            yield return null;
        }

        loadingScene.allowSceneActivation = true;

        while(!loadingScene.isDone){
            yield return null;
        }
        // loadingScene.allowSceneActivation = true;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneToLoad));
        

    }

    public void StartSceneLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("HomeScreen"));
        SceneManager.LoadSceneAsync(sceneToLoadName,LoadSceneMode.Additive);
    }
}
