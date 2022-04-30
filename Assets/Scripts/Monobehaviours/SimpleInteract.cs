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

    
}
