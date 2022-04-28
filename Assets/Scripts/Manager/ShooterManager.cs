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
    public GameObject explosion;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private GameManager gameManager;

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

        gameManager = Managers.gameManager;
    }

    private void OnMouseEnter()
    {
        if(!gameOver)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

    void Reload()
    {
        Managers.sceneManager.SingleLoad("Shooter");
    }

    void Quit()
    {
        Managers.sceneManager.ReturnToArcade();
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
                if(gameManager.getRelVal("Claire") < 1)
                {
                    gameManager.addRelVal("Claire");
                }
            }
            else
            {
                loseCanvas.SetActive(true);
                if (gameManager.getRelVal("Claire") == 0)
                {
                    gameManager.removeRelVal("Claire");
                }
            }
            buttonOptions.SetActive(true);
            gameOver = true;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);

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
                    Instantiate(explosion, new Vector3(hit.transform.position.x, hit.transform.position.y, -10), Quaternion.identity);
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
