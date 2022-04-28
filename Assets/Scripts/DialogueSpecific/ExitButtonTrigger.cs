using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonTrigger : MonoBehaviour
{
    public Button exitButton;

    public bool OverrideStart = false;
    public string OverrideSceneName;
    private string sceneToChangeTo;

    static DialogueManager dialogueManager;
    SceneManagement sceneManager;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = Managers.dialogueManager;
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        sceneToChangeTo = dialogueManager.currentSwitch;

        exitButton = GameObject.Find("Exit-Button").GetComponent<Button>();
        exitButton.onClick.AddListener(ChangeScene);
        
    }


    void ChangeScene()
     {
        if(sceneToChangeTo == "") {
            sceneManager.ReturnToArcade();
        } else {
            sceneManager.SingleLoad(sceneToChangeTo);
        }
        
        gameManager.LoadGame();

     }
}
