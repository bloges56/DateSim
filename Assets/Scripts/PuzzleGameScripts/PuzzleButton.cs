using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{   
    public PuzzleGameManager manager;
    public PuzzlePlayer2Move player2;

    void OnTriggerEnter2D(Collider2D box) {
        if(box.gameObject.tag == "PuzzleBox") {
            manager.buttons+=1;
            
            Debug.Log("Button pressed: " + manager.buttons);
        }
        if(manager.buttons == 1) {
            player2.player2AI();
        }
    
    }

    // void OnTriggerExit2D(Collider2D box) {
    //     if(box.gameObject.tag == "PuzzleBox") {
    //         manager.buttonUpdate(-1);

    //         Debug.Log("Button unpressed: " + manager.buttons);
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("PuzzleGameManager").GetComponent<PuzzleGameManager>();
        player2 = GameObject.Find("Player2").GetComponent<PuzzlePlayer2Move>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
