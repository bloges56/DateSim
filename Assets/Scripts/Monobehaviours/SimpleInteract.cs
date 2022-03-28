using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleInteract : Interactable
{
    public string infoText;
    private Canvas textCanvas;
    private void Start()
    {
        textCanvas = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Canvas>();
        createUI();
    }
    public override void inRange()
    {
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
    }

    public override void exitInteract()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        textCanvas.transform.GetChild(2).gameObject.SetActive(true);
    }

    private void createUI()
    {
        createText("Interact (E)", new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f));
        createText(infoText, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f));
        createText("Press E to Exit", new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0.5f, 0.5f));
    }

    private void createText(string text, Vector2 min, Vector2 max, Vector2 pivot)
    {
        GameObject newText = new GameObject();
        newText.transform.SetParent(textCanvas.transform);
        newText.AddComponent<TextMeshProUGUI>();
        newText.GetComponent<RectTransform>().localPosition = new Vector3(0f, 50f, 0f);
        newText.GetComponent<TextMeshProUGUI>().text = text;
        newText.GetComponent<RectTransform>().anchorMin = min;
        newText.GetComponent<RectTransform>().anchorMax = max;
        newText.GetComponent<RectTransform>().pivot = pivot;
        newText.GetComponent<TMP_Text>().alignment = TextAlignmentOptions.Center;
        newText.SetActive(false);
    }
}
