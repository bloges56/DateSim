using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInteract : Interactable
{
    public string infoText;
    
    private TMPro.TMP_Text info;
   

    private void Start()  
    {
        setup();
        info = interactText.GetComponent<TMPro.TMP_Text>();
    }

    public override void inRange()
    {
        
        info.text = infoText;
        tmpInteractText.text = "Interact (E)";
        base.inRange();
    }
 
    public override void interact()
    {
        interactText.SetActive(true);
        inRangeText.SetActive(false);
        exitText.SetActive(true);

        Time.timeScale = 0f;
    }

    
}
