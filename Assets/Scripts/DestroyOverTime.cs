using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float m_lifeTime;
    void Start()
    {
        Destroy(gameObject, m_lifeTime);
    }

}   
