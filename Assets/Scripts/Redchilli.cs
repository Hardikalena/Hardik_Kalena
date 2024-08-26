using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Redchilli : MonoBehaviour
{
    public GameObject redchilli;
    public Scoringsys logic;
    public GameObject gameoverscreen;
    // Start is called before the first frame update
    void Start()
    {
        logic = redchilli.GetComponent<Scoringsys>();
    }
    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnTriggerEnter2D(Collider2D prefab)
    {
        logic.gameOver();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
