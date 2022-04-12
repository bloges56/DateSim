using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{   
    public int buttons = 0;
    private int totalButtons = 2;
    public PuzzlePlayer2Move player2;

    public GameObject win;

    SceneManagement sceneManager;
    GameManager gameManager;


    public void buttonUpdate(int update) {
        buttons += update;
    }



    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();

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
            Time.timeScale = 0;
            Debug.Log("You win!");
            win.SetActive(true);
        }

        // if (buttons == 3 && Input.GetKeyDown(KeyCode.E)) {
        //   sceneManager.StartSceneLoad("GrayBoxMain");//Loading the scene called GrayBoxMain  
        // }
    }
}
