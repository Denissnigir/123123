using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    public int highScore;

    [Header("Set Dynamically")]
    public Text scoreGT;
    public Text scoreGG;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);

        GameObject scoreGO = GameObject.Find("HighScore");
        scoreGG = scoreGO.GetComponent<Text>();
        PlayerPrefs.SetInt("HighScore", highScore);
        scoreGG.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameObject scoreGO = GameObject.Find("Counter");
        scoreGT = scoreGO.GetComponent<Text>();
        score = int.Parse(scoreGT.text);
        score += 100;
        scoreGT.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject scoreGO = GameObject.Find("HighScore");
        scoreGG = scoreGO.GetComponent<Text>();
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        scoreGG.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        highScore = score;
    }
}
