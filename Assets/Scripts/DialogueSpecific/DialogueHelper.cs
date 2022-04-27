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
    GameObject character;
    private GameObject[] diaSceneObj;

    static SceneManagement sceneManager;
    static GameManager gameManager;

    //temp
    public int dayEdit = 1;
    private static int day;

    public void activeChar(string charName) {
        character = GameObject.Find(charName);
        animator = character.GetComponent<Animator>();
        activeCharacter = charName;
    }


    void Awake()
    {
        day = dayEdit;

        dialogueManager = Managers.dialogueManager;
        activeCharacter = dialogueManager.activeCharacter;
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager; 

        diaSceneObj = SceneManager.GetSceneByName("Dialogue").GetRootGameObjects();

        if(activeCharacter == "Deon" || activeCharacter == "PuzzleLevel1") {
            character = diaSceneObj[0];
            Debug.Log("Deon active");
            dialogueManager.activeDialogue = dialogueManager.Deon;
            dialogueManager.currentSwitch = "PuzzleLevel1";
            character.SetActive(true);
        } if (activeCharacter == "Remington") {
            character = diaSceneObj[1];
            Debug.Log("Remington active");
            dialogueManager.activeDialogue = dialogueManager.Remington;
            dialogueManager.currentSwitch = "RhythmLevelOne";
            character.SetActive(true);
        } else if (activeCharacter == "Claire") {
            character = diaSceneObj[2];
            Debug.Log("Claire active");
            dialogueManager.activeDialogue = dialogueManager.Claire;
            character.SetActive(true);
            dialogueManager.currentSwitch = "Shooter";
        }

        if(dialogueManager.activeDialogue.relationshipProgress > 0) {
            dialogueManager.currentSwitch = "Arcade";
        }
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

}
