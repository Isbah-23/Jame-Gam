using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;// = 0;

    void Start()
    {
        score = 0;
    }
    void Update()
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void AddPoints(){
        score += 10;
    }
    public int GetPoints(){
        return score;
    }
}
