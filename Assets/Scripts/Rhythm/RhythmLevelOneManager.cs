using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public class RhythmLevelOneManager : MonoBehaviour
{
    public int ORHighScore = 5;
    public int HIGHSCORE = 5;
    private float timeLeft = 60;
    string[] VALIDLETTERS = new string[] {"W","A","S","D"};
    public int currScore = 0;
    public bool completed = false;
    private int errLeft = 10;
    public float waitTime = 0.01f;
    
    public TextMeshPro[] ObjInst = new TextMeshPro[4];

    private TextMeshPro toInst;

    private TextMeshPro rhy_text;
    [SerializeField] TextMeshProUGUI curr_score_text;
    [SerializeField] TextMeshProUGUI high_score_text;
    [SerializeField] TextMeshProUGUI err_text;
    [SerializeField] TextMeshProUGUI time_left_text;

    private string highScoreText = "High Score: ";
    private string currScoreText = "Current Score: ";
    private string errLeftText = "Hearts: ";
    private string timeLeftText = "Time Left: ";
    Image img;

    SceneManagement sceneManager;
    GameManager gameManager;

    public Canvas puzzCanvas;
    public Canvas endCanvas;
    public Canvas winCanvas;

    [SerializeField] GameObject collectionObj;
    CollectionSystem collectionSyst;
    GameObject colObj;

    [SerializeField] GameObject TutorialObj;
    GameObject tutObjectInst;
    Button startButton;


    private bool loaded = false;
    public static bool destroyObj = false;
    private bool startGame = false;
    private bool loadedGame = false;
    // private bool play = false;

    // Start is called before the first frame update
    void Start()
    {
        //objects 
        puzzCanvas = GameObject.Find("RhyCanvas").GetComponent<Canvas>();
        endCanvas = GameObject.Find("EndCanvas").GetComponent<Canvas>();
        winCanvas = GameObject.Find("WinCanvas").GetComponent<Canvas>();
        endCanvas.gameObject.SetActive(false);
        winCanvas.gameObject.SetActive(false);

        //managers
        sceneManager = Managers.sceneManager;
        gameManager = Managers.gameManager; 

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

        Destroy(tutObjectInst);

        loadedGame = true;
        startGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame && loadedGame){
            timeLeft -= Time.deltaTime;

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

    public void setDestroy()
    {
        destroyObj = true;
        
    }

    void PlayGame()
    {
        if(completed){
            destroyObj = false;
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
            // currScore ++;
            AnimDown.releaseObj();
            AnimSide.stopObj();
            yield return new WaitForSeconds(waitTime);
            // completed = true;
            // Destroy(colObj);

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
        return ObjInst[Random.Range(0,VALIDLETTERS.Length)];
    }


    IEnumerator EndGame()
    {
        puzzCanvas.gameObject.SetActive(false);
        if(ORHighScore > currScore)
        {
            endCanvas.gameObject.SetActive(true);
        }
        else
        {
            winCanvas.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2.5f);
        if(!loaded)
        {
            sceneManager.SingleLoad("HomeScreen");
            loaded = true;
        }
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

    }

    public void failedScore(GameObject objTest)
    {
        Destroy(colObj);
        Destroy(objTest);
        errLeft --;   
        completed =true;

    }
}
