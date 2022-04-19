using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShooterManager : MonoBehaviour
{
    public GameObject spawn;
    public GameObject target;
    [SerializeField] float spawnTime;
    
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;
    public GameObject loseCanvas;
    public GameObject winCanvas;
    public GameObject buttonOptions;
    public GameObject instuctions;
    public AudioSource audioSource;
    public AudioClip destoryTarget;

    private float trackerTime;
    private float startRange;
    private float endRange;
    private GameObject winButton;
    private GameObject loseButton;
    private int score = 0;
    [SerializeField] float gameTime = 60f;
    [SerializeField] int winScore = 5;
    private bool gameOver = false;
    private float elapsedTime = 0f;

    private bool paused = true;
    private bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        trackerTime = spawnTime;
        startRange = spawn.transform.position.x - (spawn.transform.localScale.x / 2);
        endRange = spawn.transform.position.x + (spawn.transform.localScale.x / 2);
        timeText.text = gameTime.ToString();
        buttonOptions.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(Reload);
        buttonOptions.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(Quit);
    }

    void Reload()
    {
        Managers.sceneManager.SingleLoad("Shooter");
    }

    void Quit()
    {
        Managers.sceneManager.SingleLoad("Arcade");
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused)
        {
            gameTime -= Time.deltaTime;
        }
        else
        {
            elapsedTime += Time.deltaTime;
        }
        
        if(elapsedTime >= 3f)
        {
            paused = false;
            instuctions.SetActive(false);
        }
        if(!gameOver && gameTime <= 0)
        {
            if (win)
            {
                winCanvas.SetActive(true);
            }
            else
            {
                loseCanvas.SetActive(true);
            }
            buttonOptions.SetActive(true);
            gameOver = true;

        }

        if(!gameOver)
        {
            timeText.text = ((int)gameTime).ToString();
        }

        trackerTime -= Time.deltaTime;
        if(!paused && trackerTime <= 0f)
        {
            Vector3 spawnPoint = new Vector3(Random.Range(startRange, endRange), spawn.transform.position.y, 0f);
            Instantiate(target, spawnPoint, Quaternion.identity);
            trackerTime = spawnTime;
        }

        if (!gameOver && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.tag == "Target")
                {
                    audioSource.PlayOneShot(destoryTarget);
                    Destroy(hit.transform.gameObject);
                    score += 1;
                    scoreText.text = score.ToString();
                    if(score == winScore)
                    {
                        win = true;
                        scoreText.color = Color.green;
                    }
                }
            }
        }
    }
}
