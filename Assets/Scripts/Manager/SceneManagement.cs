using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    GameManager gameManager;

    public void SingleLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
        StartCoroutine(LoadSceneCoRou(sceneToLoadName));
    }
    
    public void AdditionalLoadToArcade(string sceneToLoadName)
    {
        GameObject[] sceneMangeSceneObj = SceneManager.GetSceneByName("Arcade").GetRootGameObjects();
        foreach(GameObject obj in sceneMangeSceneObj)
        {
            obj.SetActive(false);
        }
        StartCoroutine(LoadSceneCoRou(sceneToLoadName));

    }

    public void ReturnToArcade()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);

        GameObject[] sceneMangeSceneObj = SceneManager.GetSceneByName("Arcade").GetRootGameObjects();
        foreach(GameObject obj in sceneMangeSceneObj)
        {
            obj.SetActive(true);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Arcade"));

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

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneToLoad));
        
    }


    public void StartSceneLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("HomeScreen"));
        SceneManager.LoadSceneAsync(sceneToLoadName,LoadSceneMode.Additive);
    }

    public void DiaSceneLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Dialogue"));
        SceneManager.LoadSceneAsync(sceneToLoadName,LoadSceneMode.Additive);
    }

    public void PuzzleSceneLoad(string sceneToLoadName)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("PuzzleLevel1"));
        SceneManager.LoadSceneAsync(sceneToLoadName,LoadSceneMode.Additive);
    }

    
}
