using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
   public int m_healthAmount;
   public GameObject m_pickUpEffect;

   private void OnTriggerEnter2D(Collider2D other) {
       if(other.tag == "Player"){
           PlayerHealthController.s_instance.HealPlayer(m_healthAmount);
           if(m_pickUpEffect!=null){
               Instantiate(m_pickUpEffect, transform.position, Quaternion.identity);
           }

           Destroy(gameObject);
       }
   }

}
