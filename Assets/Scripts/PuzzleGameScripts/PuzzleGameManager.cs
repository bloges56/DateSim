using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{   
    public int buttons = 0;
    private int totalButtons = 2;
    public PuzzlePlayer2Move player2;
    static DialogueManager dialogueManager;

    

    public GameObject win;

    SceneManagement sceneManager;
    GameManager gameManager;





    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();
        dialogueManager = Managers.dialogueManager;
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;

    }



    // Update is called once per frame
    void Update()
    {
       if(buttons == totalButtons-1) {
            player2.player2AI();
        }

        if(buttons == totalButtons) {
            buttons++;
            Debug.Log("You win!");
            dialogueManager.Deon.relationshipProgress += 1;
            Debug.Log(dialogueManager.Deon.relationshipProgress);
            win.SetActive(true);
        }

        
    }
}
