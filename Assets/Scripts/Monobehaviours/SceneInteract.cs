using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneInteract : Interactable
{
   
    public string dialogueSceneName;
    public string gameSceneName;

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

    private void Update()
    {
        if(gameObject.transform.GetComponent<Collider2D>().bounds.Contains(player.transform.position))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogueInteract();
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                gameInteract();
            }
        }
    }
    
    public void dialogueInteract()
    {   
        dialogueManager.activeCharacter = gameObject.name;
        sceneManager.AdditionalLoadToArcade(dialogueSceneName);
        gameManager.LoadGame();
    }

    public void gameInteract()
    {
        sceneManager.AdditionalLoadToArcade(gameSceneName);
        gameManager.LoadGame();
    }
}
