using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField] GameObject m_bullet;
   
   float m_fireRate, m_nextFire;

   
   
   public float m_interval = 2;
   private float m_timer = 0;

    
void Start(){
    m_fireRate=1f;
    m_nextFire=Time.time;
}

void Update(){
    CheckIfTimeToFire();
}
void CheckIfTimeToFire(){
    if(Time.time>m_nextFire){
        Instantiate (m_bullet, transform.position, Quaternion.identity);
        m_nextFire = Time.time + m_fireRate; 
    }
}


//    void Update(){
//        if(m_timer>=m_interval)
//        {
//         CheckForPlayerShoot();
//         m_timer=0;
//        }
//        m_timer+=Time.DeltaTime;
//    }
//    public void CheckForPlayerShoot(){
//        if(){
           
//        }
//    }

}
