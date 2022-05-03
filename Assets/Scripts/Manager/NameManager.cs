using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Yarn.Unity;
using UnityEngine.SceneManagement;


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
    private static GameObject[] sceneMangeSceneObj; 

    void Awake()
    {  
        nameManager = GameObject.Find("NameInputManager").GetComponent<NameManager>();
        doneButton = GameObject.Find("DoneButton").GetComponent<Button>();
        inputCanvas = GameObject.Find("NameEnter").GetComponent<Canvas>();
        lastDialogue = GameObject.Find("Text");
        doneButton.gameObject.SetActive(false);
        inputCanvas.gameObject.SetActive(false);
    
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;

    }

    void Update()
    {
        if(setName == true) {
            doneButton.gameObject.SetActive(true);
            inputCanvas.gameObject.SetActive(true);
        }

        if(setName == true && Input.GetKeyDown(KeyCode.Period)){
            askForName = !askForName;
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
