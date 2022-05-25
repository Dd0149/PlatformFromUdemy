using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Start is called before the first frame update
  public float m_timetoSplode = 0.5f;
  public GameObject m_splosion;
  public float m_blastRange;
  public LayerMask m_isDestructable;
  


  void Update(){
      m_timetoSplode -= Time.deltaTime;
      if(m_timetoSplode <=0)
      {
          if(m_splosion != null)
          {
              Instantiate(m_splosion, transform.position, transform.rotation);
          }
          Destroy(gameObject);
          
          Collider2D[] objectsToRemove = Physics2D.OverlapCircleAll(transform.position, m_blastRange, m_isDestructable);
            if(objectsToRemove.Length>0){
                foreach(Collider2D col in objectsToRemove){
                    Destroy(col.gameObject);
                }
            }

      }
  }


}
