using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RandSp : MonoBehaviour
{
    public Transform[] shape;   //Reference of the Stars shapes
    public float delayshapes;   //Delay between the spawn
    public Transform[] spawnpoint;      //Points where objects will spawn
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delayshapes >= 0.3)     //To spawn Stars
        {
            Instantiate(shape[Random.Range(0, shape.Length)], spawnpoint[Random.Range(0, spawnpoint.Length)].transform.position, Quaternion.identity);
            delayshapes = 0;
        }
        delayshapes += Time.deltaTime;

    }
}
