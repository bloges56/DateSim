using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //interactable object that player is in range of
    private SimpleInteract simpleInteract;
    private SceneInteract sceneInteract;

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
        if(simpleInteract != null && Input.GetKeyDown(KeyCode.E))
        {
            //if not currently interacting, interact
            if(!interacting)
            {
                simpleInteract.interact();
                interacting = true;
            }
            //if interacting, exit interaction
            else
            {
                simpleInteract.exitInteract();
                interacting = false;
            }
        
        }
        if (sceneInteract != null && Input.GetKeyDown(KeyCode.E))
        {
            sceneInteract.interact();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is an interactable 
        if (collision.gameObject.CompareTag("Interactable"))
        {
            GameObject hitObject = collision.gameObject;
            if (hitObject != null)
            {
                simpleInteract = hitObject.GetComponent<SimpleInteract>();
                if(simpleInteract != null)
                {
                    simpleInteract.inRange();
                }
                else
                {
                    sceneInteract = hitObject.GetComponent<SceneInteract>();
                    if (sceneInteract != null)
                    {
                        Debug.Log("hit door");
                        sceneInteract.inRange();
                    }
                }
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
                simpleInteract = null;
                hitObject.outOfRange();
            }
        }
    }
}
