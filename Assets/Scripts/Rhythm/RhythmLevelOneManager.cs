using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RhythmLevelOneManager : MonoBehaviour
{
    public int ORHighScore = 5;
    public int HIGHSCORE = 5;
    public float timeLeft = 20;
    string[] VALIDLETTERS = new string[] {"W","A","S","D"};
    public int currScore = 0;
    public bool completed = false;
    private int errLeft = 3;


    [SerializeField] TextMeshProUGUI rhy_text;
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
    static DialogueManager dialogueManager;

    public Canvas puzzCanvas;
    public Canvas endCanvas;
    public Canvas winCanvas;

    private bool loaded = false;

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
        dialogueManager = Managers.dialogueManager;

        //text properties
        rhy_text.text = VALIDLETTERS[Random.Range(0,VALIDLETTERS.Length )];
        img =  GameObject.Find("Panel").GetComponent<Image>();
        img.color = UnityEngine.Color.white;
        curr_score_text.text = currScoreText + currScore.ToString();
        high_score_text.text = highScoreText + HIGHSCORE.ToString();
        err_text.text = errLeftText + errLeft.ToString(); 
        time_left_text.text = timeLeftText + timeLeft.ToString();

    
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.N)){
            rhy_text.text = NewLetter();
            img.color = UnityEngine.Color.white;
        }
        
        // StartCoroutine(PlayGame());
        PlayGame();

        curr_score_text.text = currScoreText + currScore.ToString();
        if(currScore>HIGHSCORE){
            HIGHSCORE=currScore;
        }
        high_score_text.text = highScoreText + HIGHSCORE.ToString();
        err_text.text = errLeftText + errLeft.ToString(); 
        time_left_text.text = timeLeftText + timeLeft.ToString();

    }

    void PlayGame()
    {
        if(completed){
            rhy_text.text = NewLetter();
            img.color = UnityEngine.Color.white;
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
            img.color = UnityEngine.Color.green;
            currScore ++;
            yield return new WaitForSeconds(0.5f);
            completed = true;
        }
        else{
            img.color = UnityEngine.Color.red;
            yield return new WaitForSeconds(0.5f);
            errLeft --;
            completed = true;
        }

    }

    private string NewLetter()
    {
        return VALIDLETTERS[Random.Range(0,VALIDLETTERS.Length )];
    }


    IEnumerator EndGame()
    {
        puzzCanvas.gameObject.SetActive(false);
        if(ORHighScore > currScore)
        {   
            dialogueManager.Remington.relationshipProgress = -1;
            endCanvas.gameObject.SetActive(true);
        }
        else
        {
            dialogueManager.Remington.relationshipProgress = 1;
            winCanvas.gameObject.SetActive(true);
        }
        yield return new WaitForSeconds(2.5f);
        if(!loaded)
        {
            sceneManager.SingleLoad("HomeScreen");
            loaded = true;
        }
    }
}
