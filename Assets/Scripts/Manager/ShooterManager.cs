using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public GameObject spawn;
    public GameObject target;
    [SerializeField] float spawnTime;
    private float trackerTime;
    private float startRange;
    private float endRange;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text timeText;
    public GameObject loseCanvas;
    public GameObject winCanvas;
    private int score = 0;
    [SerializeField] float gameTime = 60f;
    [SerializeField] int winScore = 5;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        trackerTime = spawnTime;
        startRange = spawn.transform.position.x - (spawn.transform.localScale.x / 2);
        endRange = spawn.transform.position.x + (spawn.transform.localScale.x / 2);
        timeText.text = gameTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if(!gameOver && gameTime <= 0)
        {
            loseCanvas.SetActive(true);
            gameOver = true;

        }

        if(!gameOver)
        {
            timeText.text = ((int)gameTime).ToString();
        }

        trackerTime -= Time.deltaTime;
        if(trackerTime <= 0f)
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
                    Destroy(hit.transform.gameObject);
                    score += 1;
                    scoreText.text = score.ToString();
                    if(score == winScore)
                    {
                        winCanvas.SetActive(true);
                        gameOver = true;
                    }
                }
            }
        }
    }
}
