using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{   
    public int buttons = 0;
    public PuzzlePlayer2Move player2;

    public GameObject win;

    //public Collider box2;
    //public Collider wall;


    public void buttonUpdate(int update) {
        buttons += update;
    }



    // Start is called before the first frame update
    void Start()
    {
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();

        //box2 = GameObject.Find("box2").GetComponent<Collider>();
        //wall = GameObject.Find("InvisibleWall").GetComponent<Collider>();

        //Physics.IgnoreCollision(box2, wall, true);
    }

    // Update is called once per frame
    void Update()
    {
       if(buttons == 1) {
            player2.player2AI();
        }

        if(buttons == 2) {
            buttons++;
            Time.timeScale = 0;
            Debug.Log("You win!");
            win.SetActive(true);
        }
    }
}
