using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Yarn.Unity;


public class NameManager : MonoBehaviour
{
    static NameManager nameManager;
    [SerializeField] TextMeshProUGUI charName;
    GameObject diaText;
    public Canvas inputCanvas;
    public Button doneButton;
    public GameObject lastDialogue;

    public string sceneToLoadNext = "Arcade";

    SceneManagement sceneManager;
    GameManager gameManager;

    public bool askForName = true;
    public bool setName = false;
    // Start is called before the first frame update

    void Start()
    {  
        nameManager = GameObject.Find("NameInputManager").GetComponent<NameManager>();
        doneButton = GameObject.Find("DoneButton").GetComponent<Button>();
        inputCanvas = GameObject.Find("NameEnter").GetComponent<Canvas>();
        lastDialogue = GameObject.Find("Text");
        doneButton.gameObject.SetActive(false);
        inputCanvas.gameObject.SetActive(false);
        // diaText = GameObject.Find("DialogueSystem");

        //inputCanvas.gameObject.SetActive(askForName); 
        // diaText.gameObject.SetActive(!askForName);

        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager; 

        //doneButton.onClick.AddListener(DoneName);
    }

    // Update is called once per frame
    void Update()
    {
        //inputCanvas.gameObject.SetActive(askForName);
        // diaText.gameObject.SetActive(!askForName);
        if(sceneManager == null || gameManager == null )
        {
            sceneManager = Managers.sceneManager;
            gameManager = Managers.gameManager;
        }

        if(setName == true) {
            doneButton.gameObject.SetActive(true);
            inputCanvas.gameObject.SetActive(true);
        }

        if(setName == true && Input.GetKeyDown(KeyCode.Period)){
            askForName = !askForName;
        }

        if(setName == true && Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Name is: "+gameManager.GetName());
        }

        if(setName == true && Input.GetKeyDown(KeyCode.Return)){
            gameManager.SetName(charName.text);
            askForName = false;
            setName = true;
            DoneName();
        }
    }

    void DoneName()
    {
        gameManager.SetName(charName.text);
        sceneManager.SingleLoad(sceneToLoadNext);

    }

    [YarnCommand("SetNameTrue")]
    public static void SetNameTrue() {
       nameManager.setName = true;
       Destroy(GameObject.Find("EventSystem"));
       nameManager.doneButton.onClick.AddListener(nameManager.DoneName);
       
    }
}
