using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    
    public float m_bulletSpeed;
    public Rigidbody2D m_theBulletRB;
    public PlayerController m_target;
    public Vector2 m_moveDir;
    public GameObject m_impactVfx;
    public GameObject m_spawnPoint;
    

    void Start(){
        //set per instance rules upon start
        m_theBulletRB = GetComponent<Rigidbody2D>();
        m_target = GameObject.FindObjectOfType<PlayerController>();
        m_moveDir=(m_target.transform.position - transform.position).normalized * m_bulletSpeed;
        m_theBulletRB.velocity = new Vector2(m_moveDir.x, m_moveDir.y);
        Destroy(gameObject, 3f);
    }
    void Update()
    {
       // m_theBulletRB.velocity = m_moveDir * m_bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Guard Clause
        if(m_impactVfx != null){
        //vfx particle system reference is made on collision.
        Instantiate(m_impactVfx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
        
    }

}
