using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D m_theRB;
   public float m_moveSpeed;
   public float m_JumpForce;

    void Update()
    {
        m_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * m_moveSpeed, m_theRB.velocity.y);

        if(Input.GetButtonDown("Jump"))
        {

             m_theRB.velocity = new Vector2(m_theRB.velocity.x, m_JumpForce);
        }
    }


}
