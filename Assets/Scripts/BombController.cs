using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Start is called before the first frame update
  public float m_timetoSplode = 0.5f;
  public GameObject m_splosion;

  void Update(){
      m_timetoSplode -= Time.deltaTime;
      if(m_timetoSplode <=0)
      {
          if(m_splosion != null)
          {
              Instantiate(m_splosion, transform.position, transform.rotation);
          }
          Destroy(gameObject);
      }
  }


}
