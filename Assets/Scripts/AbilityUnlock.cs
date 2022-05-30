using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AbilityUnlock : MonoBehaviour
{
    public bool m_unlockDoublJump, m_unlockDash, m_unlockBecomeBall, m_unlockBomb;
    public GameObject m_pickUpEffect;
    public string m_unlockMessage;
    public TMP_Text m_unlockText;

    public float m_textTimer = 3f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            PlayerAbilityTracker player = other.GetComponentInParent<PlayerAbilityTracker>();
            if(m_unlockDoublJump){
                player.m_canDoubleJump =true;
            }
            if(m_unlockDash){
                player.m_canDash =true;
            }
            if(m_unlockBecomeBall){
                player.m_canBecomeBall =true;
            }
            if(m_unlockBomb){
                player.m_canDropBomb =true;
            }
            
            Instantiate(m_pickUpEffect, transform.position, transform.rotation);
            
            m_unlockText.transform.parent.SetParent(null);
            m_unlockText.transform.parent.position=transform.position;
            
            m_unlockText.text = m_unlockMessage;
            m_unlockText.gameObject.SetActive(true);

            Destroy(m_unlockText.transform.parent.gameObject, m_textTimer);

            Destroy(gameObject);
        }
    }


}
