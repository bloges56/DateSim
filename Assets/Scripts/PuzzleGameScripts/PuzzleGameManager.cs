using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{   
    public int buttons = 0;
    private int totalButtons = 3;

    public PuzzlePlayer2Move player2;
    public GameObject instructions;
    public GameObject win;

    static DialogueManager dialogueManager;
    SceneManagement sceneManager;
    GameManager gameManager;

    IEnumerator hideInstructions (GameObject guiParentCanvas, float secondsToWait,bool show = false) {
        yield return new WaitForSeconds(secondsToWait);
        guiParentCanvas.SetActive(show);
    }


    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();
        instructions = GameObject.Find("Instructions");

        StartCoroutine (hideInstructions(instructions, 3.5f));

        dialogueManager = Managers.dialogueManager;
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;

    }

    void FixedUpdate(){
        if(buttons == totalButtons-1) {
            player2.player2AI();
        }
    }

    void Update()
    {
        if(buttons == totalButtons) {
            buttons++;
            Debug.Log("You win!");
            dialogueManager.Deon.relationshipProgress = 1;
            gameManager.addRelVal("Deon");
            Debug.Log(dialogueManager.Deon.relationshipProgress);
            win.SetActive(true);
        }

        if(buttons == totalButtons + 1 && Input.GetKeyDown(KeyCode.E)) {
            sceneManager.ReturnToArcade();
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            sceneManager.SingleLoad("PuzzleLevel1");
        }
    }
}
