using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            Interactable hitObject = collision.gameObject.GetComponent<Interactable>();
            if (hitObject != null)
            {
                Debug.Log("In Range of Interactable Object");
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
                Debug.Log("Out of Range of Interactable Object");
            }
        }
    }
}
