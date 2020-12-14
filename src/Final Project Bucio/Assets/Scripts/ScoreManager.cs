using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highscoreText;

    public float scoreCount;

    [SerializeField]
    private float highscoreCount;
    [SerializeField]
    private float pointsPerSecond;

   
    public bool isScoreIncreasing;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
        scoreCount += pointsPerSecond * Time.deltaTime;

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highscoreCount);
        }
        currentScoreText.text = "Score: " + Mathf.Round (scoreCount);
        highscoreText.text = "HighScore: " + Mathf.Round (highscoreCount);
    }
}
