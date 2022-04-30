using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneInteract : Interactable
{
   
    public string sceneName;

    private SceneManagement sceneManager;
    private GameManager gameManager;
    private DialogueManager dialogueManager;

    private void Start()
    {
        setup();
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        dialogueManager = Managers.dialogueManager;
    }
    public override void inRange()
    {
        
        tmpInteractText.text = interactableText;
        base.inRange();

    }
    
    public override void interact()
    {   
        dialogueManager.activeCharacter = gameObject.name;
        sceneManager.AdditionalLoadToArcade(sceneName);
        gameManager.LoadGame();
    }
}
