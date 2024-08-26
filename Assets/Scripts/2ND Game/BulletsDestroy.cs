using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsDestroy : MonoBehaviour
{
    public GameObject[] gameobject;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Vegies"))
        {
            Destroy(other.gameObject);      //To Destroy the Bullets
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
