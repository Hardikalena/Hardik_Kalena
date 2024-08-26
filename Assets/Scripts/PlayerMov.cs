using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMov : MonoBehaviour
{
    //public Playercol controller;
    //public float Horizontalmove = 0f;
    //public float speed = 20f;
    //public bool Jump = false;
    //public bool Attack = false;
    public Animator animator;
    //public bool grounded;
    public Rigidbody2D RB2;
    public float speed;
    public float jump;
    public BoxCollider2D boxCollider;
    public LayerMask groundedlayer;
    private void Awake()
    {
        Rigidbody2D RB2 = GetComponent<Rigidbody2D>();
        animator= GetComponent<Animator>(); 
    }
    void Start()
    {
       
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        RB2.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, RB2.velocity.y);      // for left and right
          
        if(Input.GetKey(KeyCode.Space)&&grounded() )
        {
            Jump();
        }
        if(HorizontalInput >= 0.01f)
        {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if(HorizontalInput <= -0.01f)
        {
            this.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
        animator.SetBool("Run",HorizontalInput !=0);
        animator.SetBool("grounded",grounded());

        //Horizontalmove = Input.GetAxisRaw("Horizontal")*speed;
        //animator.SetFloat("Speed", Mathf.Abs(Horizontalmove));

        //if (Input.GetButtonDown("Jump"))
        //{
        //    Jump= true;
        //    animator.SetBool("PlayerJump", true);
        //}
        //if(Input.GetButtonDown("Attack"))
        //{
        //    Attack= true;
        //    animator.SetBool("Attack", true);
        //}
        //animator.SetBool("Run",HorizontalInput != 0);
    }
    public void Jump()
    {
        RB2.velocity = new Vector2(RB2.velocity.x, jump);
        animator.SetTrigger("PlayerJump");
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    /*if(collision.gameObject.tag == "Ground")
    //    {
    //        grounded = true;
    //    }*/
    //}
    private bool grounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,boxCollider.size,0f,Vector2.down,groundedlayer);
        return raycastHit.collider != null;
        
    }
   
}
