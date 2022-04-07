using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteract : Interactable
{
    public string sceneName;
    private SceneManagement sceneManager;
    private GameManager gameManager;
    public Canvas textCanvas;

    private void Start()
    {
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
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
        sceneManager.SingleLoad(sceneName);
        gameManager.LoadGame();
    }

    public override void exitInteract()
    {
        Time.timeScale = 1f;
        textCanvas.transform.GetChild(1).gameObject.SetActive(false);
        textCanvas.transform.GetChild(0).gameObject.SetActive(true);
        textCanvas.transform.GetChild(2).gameObject.SetActive(false);
    }
}
