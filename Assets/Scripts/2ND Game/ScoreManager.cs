using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text Scoretext;
    public TMP_Text Highscoretext;
    int score = 0;
    int highscore = 0;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {

        highscore = PlayerPrefs.GetInt("highscore", 0);
        Scoretext.text=score.ToString() + " Points";
        Highscoretext.text = highscore.ToString() + " Highscore"; 
    }

    public void AddPoint()
    {
        score += 1;
        Scoretext.text=score.ToString() + " Points";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore",score); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
