using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class ButtonKeyTrigger : MonoBehaviour {
 
     public string inputName;
     Button buttonMe;
     // Use this for initialization
     void Start () {
         buttonMe = GetComponent<Button>();
     }
     
     void Update() {

         if(Input.GetKeyDown(inputName)){
             buttonMe.onClick.Invoke();
         }
        //  if(Input.GetButtonDown(inputName))
        //  {
            //  buttonMe.onClick.Invoke();
        //  }
             
 
     }
 }
 
