using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneInteract : Interactable
{
    public string interactableName;
    public string sceneName;
    private SceneManagement sceneManager;
    private GameManager gameManager;
    public Canvas textCanvas;
    private GameObject inRangeText;
    private GameObject interactText;
    private GameObject exitText;
    private TMPro.TMP_Text tmpInteractText;


    private void Start()
    {
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        inRangeText = textCanvas.transform.GetChild(0).gameObject;
        interactText = textCanvas.transform.GetChild(1).gameObject;
        exitText = textCanvas.transform.GetChild(2).gameObject;
        tmpInteractText = inRangeText.GetComponent<TMPro.TMP_Text>();
    }
    public override void inRange()
    {
        tmpInteractText.text = "Go to " + sceneName;
        inRangeText.SetActive(true);
    }
    public override void outOfRange()
    {
        inRangeText.SetActive(false);
        interactText.SetActive(false);
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
