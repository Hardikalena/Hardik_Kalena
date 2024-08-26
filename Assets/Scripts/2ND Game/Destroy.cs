using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public GameObject[] gameobject;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Vegies"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Khatam"))
        {
            Destroy(other.gameObject);
            QuitGame();
        }
       
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
