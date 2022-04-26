using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactableText;
    protected GameObject textCanvas { get; set; }
    protected GameObject inRangeText { get; set; }
    protected GameObject interactText { get; set; }
    protected GameObject exitText { get; set; }
    protected TMPro.TMP_Text tmpInteractText { get; set; }

    public void setup()
    {
        textCanvas = GameObject.Find("InteractCanvas");
        inRangeText = textCanvas.transform.GetChild(0).gameObject;
        interactText = textCanvas.transform.GetChild(1).gameObject;
        exitText = textCanvas.transform.GetChild(2).gameObject;
        tmpInteractText = inRangeText.GetComponent<TMPro.TMP_Text>();
    }

    public virtual void inRange()
    {
        inRangeText.SetActive(true);
    }
    public abstract void interact();

    public void outOfRange()
    {
        inRangeText.SetActive(false);
        interactText.SetActive(false);
    }
    public void exitInteract()
    {
        Time.timeScale = 1f;
        interactText.SetActive(false);
        inRangeText.SetActive(true);
        exitText.SetActive(false);
    }

}
