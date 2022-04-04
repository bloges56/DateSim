using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInteract : Interactable
{
    public string infoText;
    public Canvas textCanvas;

    public override void inRange()
    {
        textCanvas.transform.GetChild(1).GetComponent<TMPro.TMP_Text>().text = infoText;
        textCanvas.transform.GetChild(0).GetComponent<TMPro.TMP_Text>().text = "Interact (E)";
        textCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }
    public override void outOfRange()
    {
        textCanvas.transform.GetChild(0).gameObject.SetActive(false);
        textCanvas.transform.GetChild(1).gameObject.SetActive(false);
    }
    public override void interact()
    {
        textCanvas.transform.GetChild(1).gameObject.SetActive(true);
        textCanvas.transform.GetChild(0).gameObject.SetActive(false);
        textCanvas.transform.GetChild(2).gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public override void exitInteract()
    {
        Time.timeScale = 1f;
        textCanvas.transform.GetChild(1).gameObject.SetActive(false);
        textCanvas.transform.GetChild(0).gameObject.SetActive(true);
        textCanvas.transform.GetChild(2).gameObject.SetActive(false);
    }
}
