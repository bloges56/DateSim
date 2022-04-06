using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{   
    public int buttons = 0;
    public PuzzlePlayer2Move player2;

    public void buttonUpdate(int update) {
        buttons += update;
    }



    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buttons == 1) {
            player2.player2AI();
        }
    }
}
