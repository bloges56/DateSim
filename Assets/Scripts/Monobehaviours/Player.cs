using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private Interactable interact;
    private bool interacting = false;
    private void Update()
    {
        if(interact != null && Input.GetKeyDown(KeyCode.E))
        {
            if(!interacting)
            {
                interact.interact();
                interacting = true;
            }
            else
            {
                interact.exitInteract();
                interacting = false;
            }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Interactable hitObject = collision.gameObject.GetComponent<Interactable>();
            if (hitObject != null)
            {
                interact = hitObject;
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
