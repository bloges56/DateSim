using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInteract : Interactable
{
    public string infoText;
    public Canvas textCanvas;
    private GameObject inRangeText;
    private GameObject interactText;
    private GameObject exitText;

    private TMPro.TMP_Text info;
    private TMPro.TMP_Text interactRef;

    private void Start()
    {
        inRangeText = textCanvas.transform.GetChild(0).gameObject;
        interactText = textCanvas.transform.GetChild(1).gameObject;
        exitText = textCanvas.transform.GetChild(2).gameObject;

        info = interactText.GetComponent<TMPro.TMP_Text>();
        interactRef = inRangeText.GetComponent<TMPro.TMP_Text>();
    }

    public override void inRange()
    {
        
        info.text = infoText;
        interactRef.text = "Interact (E)";
        inRangeText.SetActive(true);
    }
    public override void outOfRange()
    {
        inRangeText.SetActive(false);
        interactText.SetActive(false);
    }
    public override void interact()
    {
        interactText.SetActive(true);
        inRangeText.SetActive(false);
        exitText.SetActive(true);

        Time.timeScale = 0f;
    }

    public override void exitInteract()
    {
        Time.timeScale = 1f;
        interactText.SetActive(false);
        inRangeText.SetActive(true);
        exitText.SetActive(false);
    }
}
