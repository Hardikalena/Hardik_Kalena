using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{

    public GameObject[] gameobject;
    public float Lifetime = 3f;
    // Update is called once per frame
    void Update()
    {
        if (Lifetime > 0)   
        {
            Lifetime -= Time.deltaTime;
            if (Lifetime < 0)
            {
                Destroy(gameObject);    //To destroy stars
            }
        }
    }
}
