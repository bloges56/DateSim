using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //interactable object that player is in range of
    private SimpleInteract interact;

    //tracks if player is currently interacting with something
    private bool interacting = false;

    private GameObject interactText;


    private void Start()
    {
        interactText = GameObject.FindGameObjectWithTag("InteractUI");
        Debug.Log(interactText.name);
        
    }
    private void Update()
    {
        //if there is an object in range and when the player hits E
        if(interact != null && Input.GetKeyDown(KeyCode.E))
        {
            //if not currently interacting, interact
            if(!interacting)
            {
                interact.interact();
                interacting = true;
            }
            //if interacting, exit interaction
            else
            {
                interact.exitInteract();
                interacting = false;
            }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is an interactable 
        if (collision.gameObject.CompareTag("Interactable"))
        {
            SimpleInteract hitObject = collision.gameObject.GetComponent<SimpleInteract>();
            if (hitObject != null)
            {
                interact = hitObject;
                interactText.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = interact.infoText;
                hitObject.inRange();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Interactable hitObject = collision.gameObject.GetComponent<Interactable>();
            if (hitObject != null)
            {
                interact = null;
                hitObject.outOfRange();
            }
        }
    }
}
