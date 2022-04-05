using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleButton : MonoBehaviour
{   
    public PuzzleGameManager manager;

    void OnTriggerEnter2D(Collider2D box) {
        if(box.gameObject.tag == "PuzzleBox") {
            manager.buttonsPressed++;
            
            Debug.Log("Buttons pressed: "+ manager.buttonsPressed);
        }
         
    }

    void OnTriggerExit2D(Collider2D box) {
        if(box.gameObject.tag == "PuzzleBox") {
            manager.buttonsPressed--;
            Debug.Log("Buttons pressed: " + manager.buttonsPressed);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
