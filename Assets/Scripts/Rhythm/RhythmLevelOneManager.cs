using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class RhythmLevelOneManager : MonoBehaviour
{
    //Managers
    SceneManagement sceneManager;
    GameManager gameManager;
    DialogueManager dialogueManager;

    //Scores
    public int ORHighScore = 5;
    public int HIGHSCORE = 5;
    public int currScore = 0;

    //Time management
    public float timer = 30;
    private int timeLeft;

    //End criteria
    public bool completed = false;
    private int errLeft = 10;
    public float waitTime = 0.01f;

    //Text Prefabs
    public TextMeshPro[] ObjInst = new TextMeshPro[4];
    private TextMeshPro toInst;
    private TextMeshPro rhy_text;

    //Displayed Text
    [SerializeField] TextMeshProUGUI curr_score_text;
    [SerializeField] TextMeshProUGUI high_score_text;
    [SerializeField] TextMeshProUGUI err_text;
    [SerializeField] TextMeshProUGUI time_left_text;
    private string highScoreText = "High Score: ";
    private string currScoreText = "Current Score: ";
    private string errLeftText = "Hearts: ";
    private string timeLeftText = "Time Left: ";

    //Canvases
    [SerializeField] Canvas puzzCanvas;
    [SerializeField] Canvas endCanvas;
    [SerializeField] Canvas winCanvas;

    //Collection system
    [SerializeField] GameObject collectionObj;
    CollectionSystem collectionSyst;
    GameObject colObj;

    //Tutorial system
    [SerializeField] GameObject TutorialObj;
    GameObject tutObjectInst;
    Button startButton;

    //Game Variables
    private bool loaded = false;
    private bool startGame = false;
    private bool loadedGame = false;

    //End Screen buttons
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    bool restartGame = false;

    //Sound
    private AudioSource audioSource;

    void Start()
    {
        //managers
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager;
        dialogueManager = Managers.dialogueManager;

        audioSource = this.gameObject.GetComponent<AudioSource>();

        if(!startGame)
        {
            tutObjectInst = Instantiate(TutorialObj);
            startButton = GameObject.Find("Tut-Start-Button").GetComponent<Button>();
            startButton.onClick.AddListener(StartGame);
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)){
                StartGame();
            }
        }

    }

    void StartGame()
    {
        puzzCanvas.gameObject.SetActive(true);
        colObj = Instantiate(collectionObj);
        collectionSyst = colObj.GetComponent<CollectionSystem>();


        //text properties
        toInst = ObjInst[Random.Range(0,ObjInst.Length)];
        rhy_text = Instantiate(toInst);
        rhy_text.color = UnityEngine.Color.black;
        curr_score_text.text = currScoreText + currScore.ToString();
        high_score_text.text = highScoreText + HIGHSCORE.ToString();
        err_text.text = errLeftText + errLeft.ToString();
        time_left_text.text = timeLeftText + timeLeft.ToString();

        if(tutObjectInst!= null)
        {
            Destroy(tutObjectInst);
        }
        loadedGame = true;
        startGame = true;
    }

    void Update()
    {
        if(startGame && loadedGame){
            restartGame = false;
            timer -= Time.deltaTime;
            timeLeft = (int)(timer%60);

            PlayGame();
            curr_score_text.text = currScoreText + currScore.ToString();
            if(currScore>HIGHSCORE){
                HIGHSCORE=currScore;
            }
            high_score_text.text = highScoreText + HIGHSCORE.ToString();
            err_text.text = errLeftText + errLeft.ToString();
            time_left_text.text = timeLeftText + timeLeft.ToString();
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)){
                StartGame();
            }
        }

    }

    void PlayGame()
    {
        if(completed){
            colObj = Instantiate(collectionObj);
            collectionSyst = colObj.GetComponent<CollectionSystem>();

            toInst = NewLetter();
            rhy_text = Instantiate(toInst);
            AnimDown.stopObj();
            AnimSide.releaseObj();
            rhy_text.color = UnityEngine.Color.black;
            completed = false;

        }

        if(Input.anyKeyDown && errLeft > 0 && timeLeft>0)
        {
            if(Input.GetKeyDown(KeyCode.W)){
            StartCoroutine(MatchLetter("W"));

            }
            else if(Input.GetKeyDown(KeyCode.A)){
                StartCoroutine(MatchLetter("A"));

            }
            else if(Input.GetKeyDown(KeyCode.S)){
                StartCoroutine(MatchLetter("S"));

            }
            else if(Input.GetKeyDown(KeyCode.D)){
                StartCoroutine(MatchLetter("D"));

            }
        }
        else if(errLeft < 1 || timeLeft <1)
        {
            StartCoroutine(EndGame());
        }

    }

    IEnumerator MatchLetter(string letter)
    {
        if(rhy_text.text == letter){
            rhy_text.color = UnityEngine.Color.green;
            AnimDown.releaseObj();
            AnimSide.stopObj();
            yield return new WaitForSeconds(waitTime);
        }
        else{
            rhy_text.color = UnityEngine.Color.red;
            AnimDown.stopObj();
            AnimSide.stopObj();
            yield return new WaitForSeconds(waitTime);
            errLeft --;
            completed = true;
            Destroy(rhy_text.gameObject);
            Destroy(colObj);
        }

    }

    private TextMeshPro NewLetter()
    {
        return ObjInst[Random.Range(0,ObjInst.Length)];
    }


    IEnumerator EndGame()
    {
        puzzCanvas.gameObject.SetActive(false);

        if(ORHighScore < currScore)
        {
            winCanvas.gameObject.SetActive(true);
            yield return new WaitForSeconds(2.5f);
            dialogueManager.Remington.relationshipProgress = 1;
            ExitGame();
        }
        else
        {
            endCanvas.gameObject.SetActive(true);
            dialogueManager.Remington.relationshipProgress = -1;
            restartButton.onClick.AddListener(RestartGame);
            exitButton.onClick.AddListener(ExitGame);
            yield return new WaitForSeconds(2.5f);
        }
    }

    private void ExitGame()
    {
        if(!loaded)
        {
            sceneManager.SingleLoad("Arcade");
        }
        loaded = true;
    }
    private void RestartGame()
    {
        if(!loaded){
            sceneManager.SingleLoad("RhythmLevelOne");
        }
        loaded = true;
    }

    public void checkScore(GameObject objTest)
    {
        collectionSyst.checkCollisionResult(objTest);
    }

    public void succScore(GameObject objTest)
    {
        Destroy(colObj);
        Destroy(objTest);
        currScore ++;
        completed =true;
        audioSource.Play();
    }

    public void failedScore(GameObject objTest)
    {
        Destroy(colObj);
        Destroy(objTest);
        errLeft --;
        completed =true;
    }
}
