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

        sceneToChangeTo = dialogueManager.currentSwitch;
        exitButton = GameObject.Find("Exit-Button").GetComponent<Button>();

        exitButton.onClick.AddListener(ChangeScene);

        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
    }


    void ChangeScene()
     {
         if(OverrideStart)
         {
             sceneManager.DiaSceneLoad(OverrideSceneName);
         }
         else
         {
            sceneManager.DiaSceneLoad(sceneToChangeTo);
         }
        gameManager.LoadGame();

     }
}
