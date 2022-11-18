using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] static int score;
    const int DEFAULT_POINTS = 1;
    int SCORE_THRESHOLD = 10;
    [SerializeField] Text scoreTxt;
    [SerializeField] Text sceneTxt;
    [SerializeField] Text nameTxt;
    [SerializeField] int level;

    // Start is called before the first frame update
    void Start()
    {
        score = PersistentData.Instance.GetScore();
        level = SceneManager.GetActiveScene().buildIndex;
        DisplayLevel();
        DisplayScore();
        DisplayName();
        SCORE_THRESHOLD *= (level-2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score " + score);
        DisplayScore();
        PersistentData.Instance.SetScore(score);

        if (score >= SCORE_THRESHOLD){
            AdvanceLevel();
        }

    }


    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void DisplayScore()
    {
        scoreTxt.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        sceneTxt.text = "Level: " + (level-2);
    }

    public void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }

    public void DisplayName()
    {
        nameTxt.text = "Greetings, " + PersistentData.Instance.GetName() + " good luck.";
    }
}
