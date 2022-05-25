using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEnemyController : MonoBehaviour
{
        
    public float m_timer = 5;
   public float m_min;
   public float m_max;
   public GameObject m_targetPlayer;
   public GameObject[] m_CoinEnemy;
   public GameObject m_enemyBullet;

    private void Update()
   {
    //    m_timer mt = Time.deltaTime;          
    //     if(mt-=0)
    //     {
    //        if(m_standing.activeSelf)
    //        {
   
    //         Instantiate(m_shotToFire, m_shotPoint.position, m_shotPoint.rotation).m_moveDir = new Vector2(transform.localScale.x, 0f);
    //         m_anim.SetTrigger("isShoot");

    //         }
    //     }




}
}
