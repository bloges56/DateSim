using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if collision is an interactable 
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Interactable hitObject = collision.gameObject.GetComponent<Interactable>();
            if (hitObject != null)
            {
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
                hitObject.outOfRange();
            }
        }
    }
}
