using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Scoringsys : MonoBehaviour
{
    public Text Score;
    public Text endScore;
    private int scorenum;
    public GameObject gameoverscreen;
    public Scoringsys logic;
    public GameObject redchilli;
    // Start is called before the first frame update
    void Start()
    {
        scorenum= 0;
        Score.text = "Score :" + scorenum;
        logic = redchilli.GetComponent<Scoringsys>();
    }
    public void gameOver()
    {
        gameoverscreen.SetActive(true);
        endScore.text = Score.text;
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void OnTriggerEnter2D(Collider2D redchilli)
    {
        if(redchilli.tag == "Vegies")
        {
            scorenum++;
            Destroy(redchilli.gameObject);
            Score.text = "Score:" + scorenum;
            //logic.gameOver();
            
        }
        else if(redchilli.tag == "Biohazard")
        {
            gameOver();
        }
       
    }

}
