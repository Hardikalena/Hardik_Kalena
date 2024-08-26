using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Shapegen : MonoBehaviour
{
    public Transform[] shape;   //Reference of the shapes
    public float delayshapes;   //Delay between the spawn
    public Transform[] spawnpoint;  //Points where objects will spawn
    private Rigidbody2D rb;     
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(delayshapes>=-1)     //To Spawn Enemy
        {
            Instantiate(shape[Random.Range(0, shape.Length)], spawnpoint[Random.Range(0, spawnpoint.Length)].transform.position, Quaternion.identity);
            delayshapes--;
        }
        delayshapes += Time.deltaTime;
        
    }
}
