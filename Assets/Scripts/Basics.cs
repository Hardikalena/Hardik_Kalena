using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics : MonoBehaviour
{
    public GameObject leftarm;
    public GameObject rightarm;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        
        //Debug.Log("Capsule : "+transform.position);
        //Debug.Log("Capsulescale : "+transform.localScale);
        //left();
        //right();
        //leftarm.SetActive(false);
        //FOR();
    }
    void left()
    {
        Debug.Log("LeftArm : " +leftarm.transform.localPosition);
        Debug.Log("LeftArmscale : " + leftarm.transform.localScale);
    }
    void right()
    {
        Debug.Log("RightArm : " +rightarm.transform.localPosition);
        Debug.Log("RightArmscale : " + rightarm.transform.localScale);
    }
    void FOR()
    {
        for(i=0;i<=100;i++)
        {
            Debug.Log(Random.Range(0,100));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
