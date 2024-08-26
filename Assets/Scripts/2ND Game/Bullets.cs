using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject spawnpoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet,spawnpoint.transform.position,Quaternion.identity);      //To Fire Bullet from player
        }
    }
}
