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

    //temp
    public int dayEdit = 1;
    private static int day;
    public string playerNameEdit = "Name";
    private static string playerName;

    //access methods 
    // public void imgSetActive(string charName, bool val) {
    //     character = GameObject.Find(charName);
    //     character.SetActive(val);
    // }

    public void activeChar(string charName) {
        character = GameObject.Find(charName);
        animator = character.GetComponent<Animator>();
        activeCharacter = charName;
    }


    void Awake()
    {
        day = dayEdit;
        playerName = playerNameEdit;

        dialogueManager = Managers.dialogueManager;
        activeCharacter = dialogueManager.activeCharacter;

        diaSceneObj = SceneManager.GetSceneByName("Dialogue").GetRootGameObjects();
        character = diaSceneObj[0];

        if(activeCharacter == "Deon") {
            Debug.Log("Deon active");
            dialogueManager.activeDialogue = dialogueManager.Deon;
            character.SetActive(true);
        } else if (activeCharacter == "Remmington") {
            Debug.Log("Remmington active");
            dialogueManager.activeDialogue = dialogueManager.Remmington;
            character.SetActive(true);
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
       return dialogueManager.activeDialogue.relationshipProgress;
    }

    [YarnFunction("ReturnDay")]
    public static int ReturnDay() {
       return day;
    }

    [YarnFunction("ReturnPlayerName")]
    public static string ReturnPlayerName() {
       return playerName.ToString();
    }

    [YarnFunction("ReturnActiveCharacter")]
    public static string ReturnActiveCharacter() {
        return activeCharacter;
    }

}
