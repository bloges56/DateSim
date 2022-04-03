using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteract : Interactable
{
    public string sceneName;
    private SceneManagement sceneManager;
    private GameObject[] sceneManageSceneObj;
    public Canvas textCanvas;

    private void Start()
    {
        sceneManageSceneObj = SceneManager.GetSceneByName("SceneManager").GetRootGameObjects();
        sceneManager = sceneManageSceneObj[4].GetComponent<SceneManagement>();
    }
    public override void inRange()
    {
        textCanvas.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = "Go to " + sceneName;
        textCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }
    public override void outOfRange()
    {
        textCanvas.transform.GetChild(0).gameObject.SetActive(false);
        textCanvas.transform.GetChild(1).gameObject.SetActive(false);
    }
    public override void interact()
    {
        SceneManager.SetActiveScene(gameObject.scene);
        sceneManager.SingleLoad(sceneName);
    }

    public override void exitInteract()
    {
        Time.timeScale = 1f;
        textCanvas.transform.GetChild(1).gameObject.SetActive(false);
        textCanvas.transform.GetChild(0).gameObject.SetActive(true);
        textCanvas.transform.GetChild(2).gameObject.SetActive(false);
    }
}
