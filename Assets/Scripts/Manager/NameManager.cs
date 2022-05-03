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

    SceneManagement sceneMan;
    GameManager gameMan;

    public bool askForName = true;
    public bool setName = false;
    private static GameObject[] sceneMangeSceneObj; 

    // Start is called before the first frame update

    void Awake()
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

        // sceneMan = 

        // sceneMangeSceneObj = SceneManager.GetSceneByName("SceneManagerScene").GetRootGameObjects();
        // if(sceneMangeSceneObj.Length < 1 || sceneMangeSceneObj == null)
        // {
        //     Debug.LogError("Unable to locate scene.");
        // }
        // // sceneMan = sceneMangeSceneObj[0].GetComponent<SceneManagement>();
        // // gameMan = sceneMangeSceneObj[1].GetComponent<GameManager>();


        // sceneMan = sceneMangeSceneObj[0].gameObject.GetComponent<SceneManagement>();
        // gameMan= sceneMangeSceneObj[1].gameObject.GetComponent<GameManager>();
        // dialogueManager = sceneMangeSceneObj[2].GetComponent<DialogueManager>();

        // sceneMan = Managers.GetSceneManager();
        // gameMan = Managers.GetGameManager(); 

        sceneMan = Managers.sceneManager;
        gameMan = Managers.gameManager;

        if(sceneMan){
            Debug.Log("Found scene manager");
        }
        else{
            Debug.LogError("Faiedl to find scene manage");
        }

        if(gameMan){
            Debug.Log("Found game manager");
        }
        else{
            Debug.LogError("Faiedl to find game manage");
        }


    }

    // Update is called once per frame
    void Update()
    {
        //inputCanvas.gameObject.SetActive(askForName);
        // diaText.gameObject.SetActive(!askForName);


        if(setName == true) {
            doneButton.gameObject.SetActive(true);
            inputCanvas.gameObject.SetActive(true);
        }

        if(setName == true && Input.GetKeyDown(KeyCode.Period)){
            askForName = !askForName;
        }

        if(setName == true && Input.GetKeyDown(KeyCode.B)){
            Debug.Log("Name is: "+gameMan.GetName());
        }

        if(setName == true && Input.GetKeyDown(KeyCode.Return)){
            try
            {
                gameMan.SetName(charName.text);
            }
            catch(MissingComponentException)
            {

            }

            askForName = false;
            setName = true;
            DoneName();
        }
    }

    void DoneName()
    {
        gameMan.SetName(charName.text);
        sceneMan.SingleLoad(sceneToLoadNext);

    }

    [YarnCommand("SetNameTrue")]
    public static void SetNameTrue() {
       nameManager.setName = true;
       Destroy(GameObject.Find("EventSystem"));
       nameManager.doneButton.onClick.AddListener(nameManager.DoneName);
       
    }
}
