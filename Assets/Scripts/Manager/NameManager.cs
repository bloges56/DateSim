using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class NameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI charName;
    GameObject diaText;
    public Canvas inputCanvas;
    public Button doneButton;

    public string sceneToLoadNext = "Arcade";

    SceneManagement sceneManager;
    GameManager gameManager;

    public bool askForName = false;
    public bool setName = false;
    // Start is called before the first frame update
    void Start()
    {  
        doneButton = GameObject.Find("DoneButton").GetComponent<Button>();
        inputCanvas = GameObject.Find("NameEnter").GetComponent<Canvas>();
        diaText = GameObject.Find("DialogueSystem");
        inputCanvas.gameObject.SetActive(false); 
        diaText.gameObject.SetActive(!askForName);

        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager; 

        doneButton.onClick.AddListener(DoneName);
    }

    // Update is called once per frame
    void Update()
    {
        inputCanvas.gameObject.SetActive(askForName);
        diaText.gameObject.SetActive(!askForName);


        if(Input.GetKeyDown(KeyCode.Period)){
            askForName = !askForName;
        }

        if(Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Name is: "+gameManager.GetName());
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            gameManager.SetName(charName.text);
            askForName = false;
            setName = true;
        }
    }

    void DoneName()
    {
        gameManager.SetName(charName.text);
        sceneManager.SingleLoad(sceneToLoadNext);

    }
}
