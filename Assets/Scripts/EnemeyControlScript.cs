using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyControlScript : MonoBehaviour
{
   public Rigidbody2D m_theRB;
   public float m_moveSpeed;
   public BulletController m_shotToFire;
   public Transform m_shotPoint;
   public Animator m_anim;
  // public EnemyBullet m_shotToFire2;


    void Start(){
        
    }


    void Update()
    {
      
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(m_shotToFire, m_shotPoint.position, m_shotPoint.rotation).m_moveDir = new Vector2(transform.localScale.x, 0f);
            m_anim.SetTrigger("isShoot");            

        }


 
      


 
}
}
