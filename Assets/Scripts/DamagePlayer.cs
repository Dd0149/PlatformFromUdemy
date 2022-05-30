using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int m_damageAmount = 1;
    public bool m_destroyOnDamage;
    public GameObject m_destroyEffects;

    //note on the two parameters called on next two functions the evrent is called for collision2d
    //
   private void OnCollisionEnter2D(Collision2D p_collision){
        if(p_collision.gameObject.tag == "Player"){
            ImpactDamage();
        }

   }
    private void OnTriggerEnter2D(Collider2D p_trigger){
        if(p_trigger.tag == "Player"){
            ImpactDamage();
        }

    }
    //Singleton == only one version of a object exist at any time.
    void ImpactDamage(){
        PlayerHealthController.s_instance.DamagePlayer(m_damageAmount);
        if(m_destroyOnDamage){
            if(m_destroyEffects!=null){
                Instantiate(m_destroyEffects, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }

    }
}
