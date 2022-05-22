using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float m_bulletSpeed;
    public Rigidbody2D m_theBulletRB;
    public Vector2 m_moveDir;
    public GameObject m_impactVfx;
 
    void Update()
    {
        m_theBulletRB.velocity = m_moveDir * m_bulletSpeed;
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
    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
}
