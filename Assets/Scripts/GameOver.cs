using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //public Text Points;
    //public void setup(int score)
    //{
    //    gameObject.SetActive(true);
    //    Points.text = score.ToString() + "Scored Points";
    //}

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
