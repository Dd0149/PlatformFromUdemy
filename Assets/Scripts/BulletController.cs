using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float m_bulletSpeed;
    public Rigidbody2D m_theBulletRB;
    public Vector2 m_moveDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_theBulletRB.velocity = m_moveDir * m_bulletSpeed;
    }
}
