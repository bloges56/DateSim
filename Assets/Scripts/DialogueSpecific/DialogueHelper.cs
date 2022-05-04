using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class DialogueHelper : MonoBehaviour
{   
    static string activeCharacter;
    static DialogueManager dialogueManager;
    Animator animator;
    Renderer character;
    Renderer Deon;
    Renderer Claire;
    Renderer Remington;

    static SceneManagement sceneManager;
    static GameManager gameManager;

    //temp
    public int dayEdit = 1;
    private static int day;

    // public void activeChar(string charName) {
    //     character = GameObject.Find(charName);
    //     animator = character.GetComponent<Animator>();
    //     activeCharacter = charName;
    // }


    void Awake()
    {
        day = dayEdit;
        Deon = GameObject.Find("Deon").GetComponent<Renderer>();
        Deon.enabled = false;
        Remington = GameObject.Find("Remington").GetComponent<Renderer>();
        Remington.enabled = false;
        Claire = GameObject.Find("Claire").GetComponent<Renderer>();
        Claire.enabled = false;


        dialogueManager = Managers.dialogueManager;
        activeCharacter = dialogueManager.activeCharacter;
        Debug.Log(activeCharacter);
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager; 

        if(activeCharacter == "Deon") {
            character = Deon;
            dialogueManager.activeDialogue = dialogueManager.Deon;
            dialogueManager.currentSwitch = "PuzzleLevel1";
            character.enabled = true;
        } if (activeCharacter == "Remington") {
            character = Remington;
            dialogueManager.activeDialogue = dialogueManager.Remington;
            dialogueManager.currentSwitch = "RhythmLevelOne";
            character.enabled = true;
        } else if (activeCharacter == "Claire") {
            character = Claire;
            dialogueManager.activeDialogue = dialogueManager.Claire;
            dialogueManager.currentSwitch = "Shooter";
            character.enabled = true;
        }

        if(dialogueManager.activeDialogue.relationshipProgress != 0) {
            dialogueManager.currentSwitch = "";
        }
    }

    // void Update() {
    //     if(Input.GetKeyDown(KeyCode.S)) {
    //         ChangeScene();
    //     }
    // }

    public void ChangeScene()
     {
        if(dialogueManager.currentSwitch == "" || dialogueManager.currentSwitch == "Arcade") {
            sceneManager.ReturnToArcade();
        } else {
            sceneManager.SingleLoad(dialogueManager.currentSwitch);
        }
        
        //gameManager.LoadGame();
     }

    //yarn animation commands
    [YarnCommand("PlaySadAnim")]
    public void PlaySadAnim()
    {
        animator.SetBool("Sad", true);
    }
    [YarnCommand("StopSadAnim")]
    public void StopSadAnim()
    {
        animator.SetBool("Sad", false);
    }

    //yarn functions
    [YarnFunction("ReturnRelationshipProgress")]
    public static int ReturnRelationshipProgress() {
        Debug.Log(dialogueManager.activeDialogue.relationshipProgress);
       return dialogueManager.activeDialogue.relationshipProgress;
    }

    [YarnFunction("ReturnDay")]
    public static int ReturnDay() {
       return day;
    }

    [YarnFunction("ReturnPlayerName")]
    public static string ReturnPlayerName() {
       return gameManager.GetName();
    }

    [YarnFunction("ReturnActiveCharacter")]
    public static string ReturnActiveCharacter() {
        return activeCharacter;
    }

    [YarnCommand("Finish")]
    public static void Finish() {
       GameObject.Find("DialogueHelper").GetComponent<DialogueHelper>().ChangeScene();
       
    }

}
