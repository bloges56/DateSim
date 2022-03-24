using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonKeyTrigger : MonoBehaviour
{
    public string inputName;
    Button buttonMe;

    void Start () {
        buttonMe = GetComponent<Button>();
    }
     
    void Update() {

        if(Input.GetKeyDown(inputName)){
            buttonMe.onClick.Invoke();
        }            
 
     }
}
