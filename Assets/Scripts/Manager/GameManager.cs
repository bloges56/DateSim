using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    static public bool started = false;
    public string playerName = " ";

    //Scoreboard stuff
    [SerializeField] Canvas scoreBoard;
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] ScoreboardManager scoreboard;

    [SerializeField] Canvas escMenu;
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;

    DialogueManager dialogueManager;

    //Relationships
    Dictionary<string, int> relationshipVals = new Dictionary<string, int>(){
	{"Deon", 0},
	{"Claire", 0},
	{"Remington", 0}};

    void Start()
    {
        started = false;
        continueButton.onClick.AddListener(ContinueGame);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(EndGame);

        dialogueManager = GameObject.FindWithTag("DialogueManager").GetComponent<DialogueManager>();

        if(!started)
        {
            started = true;
            StartGame();
        }
    }

    void Update()
    {
        if(started){
            scoreBoard.gameObject.SetActive(Input.GetKey(KeyCode.Tab));
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pausedgame();
            }
        }
    }

    void StartGame()
    {
        SceneManager.LoadSceneAsync("HomeScreen",LoadSceneMode.Additive);
    }

    public void LoadGame(){
        started = true;
    }

    public void SetName(string inputName)
    {
        playerName = inputName;
        playerNameText.text = inputName;
    }

    public string GetName()
    {
        return playerName;
    }

    public int getRelVal(string name)
    {
        return relationshipVals[name];
    }

    public void addRelVal(string name)
    {
        relationshipVals[name] = 1;

        switch(name)
        {
        case "Deon":
            scoreboard.updateHearts("Deon",true, relationshipVals[name]);
            break;
        case "Claire":
            scoreboard.updateHearts("Claire",true, relationshipVals[name]);
            break;
        case "Remington":
            scoreboard.updateHearts("Remington",true, relationshipVals[name]);
            break;
        default:
            break;
        }
    }

    public void removeRelVal(string name)
    {
        if(relationshipVals[name] == 0){
            relationshipVals[name] = -1;

            switch(name)
            {
            case "Deon":
                scoreboard.updateHearts("Deon",false, relationshipVals[name]);
                break;
            case "Claire":
                scoreboard.updateHearts("Claire",false, relationshipVals[name]);
                break;
            case "Remington":
                scoreboard.updateHearts("Remington",false, relationshipVals[name]);
                break;
            default:
                break;
            }
        }
    }

    void Pausedgame()
    {
        escMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;

    }
    void ContinueGame()
    {
        escMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
   void RestartGame()
   {
        Time.timeScale = 1.0f;

        // dialogueManager.relationshipProgress = 0;
        dialogueManager.Remington.relationshipProgress = 0;
        dialogueManager.Claire.relationshipProgress = 0;
        dialogueManager.Deon.relationshipProgress = 0;
        dialogueManager.activeCharacter = "";
        // nameManager.setName = true;

        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];

        for (int i = 0; i < countLoaded; i++)
        {
            loadedScenes[i] = SceneManager.GetSceneAt(i);
        }
        foreach (Scene item in loadedScenes)
        {
            SceneManager.UnloadSceneAsync(item);

        }

        SceneManager.LoadSceneAsync("SceneManagerScene");
    }
    void EndGame()
    {
        Application.Quit();

    }



}
