using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerCrab : MonoBehaviour
{
    public Transform[] m_patrolPoints;
    private int m_currentPoint;
    public float m_moveSpeed, m_waitAtPoints;
    private float m_waitToCounter;
    public float m_jumpForce;
    public Animator m_anim;

    public Rigidbody2D m_theRB;

    void Start(){
        m_waitToCounter = m_waitAtPoints;
        foreach(Transform pPoints in m_patrolPoints){
            pPoints.SetParent(null);
        }
    }

    void Update(){
        if(Mathf.Abs(transform.position.x - m_patrolPoints[m_currentPoint].position.x)>.2f)
        {
            if(transform.position.x<m_patrolPoints[m_currentPoint].position.x)
            {
                m_theRB.velocity = new Vector2(m_moveSpeed, m_theRB.velocity.y);
                transform.localScale=new Vector3(-1f,1f,1f);
            }
            else{
                m_theRB.velocity = new Vector2(-m_moveSpeed, m_theRB.velocity.y);
                transform.localScale = Vector3.one;
            }
            if(transform.position.y<m_patrolPoints[m_currentPoint].position.y - .5f && m_theRB.velocity.y <.1f){
                m_theRB.velocity = new Vector2(m_theRB.velocity.x, m_jumpForce);
            }

        }else{
            m_theRB.velocity = new Vector2(0f, m_theRB.velocity.y);
           
            m_waitToCounter-= Time.deltaTime;
            if(m_waitToCounter<=0){
                m_waitToCounter = m_waitAtPoints;
                m_currentPoint++;
                if(m_currentPoint>=m_patrolPoints.Length){
                    m_currentPoint=0;
                }
            }
        }
        m_anim.SetFloat("speed", Mathf.Abs(m_theRB.velocity.x));
    }


}
