using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{   
    public PuzzleGameManager manager;

    void OnTriggerEnter2D(Collider2D box) {
        if(box.gameObject.tag == "PuzzleBox") {
            manager.buttonUpdate(1);
            
            Debug.Log("Button pressed: " + manager.buttons);
        }
         
    }

    void OnTriggerExit2D(Collider2D box) {
        if(box.gameObject.tag == "PuzzleBox") {
            manager.buttonUpdate(-1);

            Debug.Log("Button unpressed: " + manager.buttons);
            if(manager.buttons == 1) {
                manager.player2AI();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("PuzzleGameManager").GetComponent<PuzzleGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
