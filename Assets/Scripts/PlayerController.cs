using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D m_theRB;
   public float m_moveSpeed;
   public float m_JumpForce;
   public Transform m_groundPoint;
   private bool isOnGround;
   public LayerMask whatIsGround;

   public Animator m_anim;


    void Update()
    {
        //move sideways
        m_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * m_moveSpeed, m_theRB.velocity.y);
        //handle direction change
       if(m_theRB.velocity.x < 0){
           transform.localScale = new Vector3(-1f,1f,1f);
       }
       else if(m_theRB.velocity.x >0){
           transform.localScale = Vector3.one;
       }
        //checking if on the ground
        isOnGround = Physics2D.OverlapCircle(m_groundPoint.position, .2f, whatIsGround);
        if(Input.GetButtonDown("Jump") && isOnGround)
        {

             m_theRB.velocity = new Vector2(m_theRB.velocity.x, m_JumpForce);
        }


        m_anim.SetBool("isOnGround", isOnGround);
        m_anim.SetFloat("Speed", Mathf.Abs(m_theRB.velocity.x));








    }


}
