using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController s_instance;

    
    private void Awake(){
        s_instance=this;
    }
    //question 1: do you want it graphical? UI? just logic then graphic?
    //are you visual unity then code or code then visual?
    [HideInInspector]//hide this to prevent otehr in group devop from thinking they have to change it.
    public int m_currentHealth;
    public int m_maxHealth;
    public float m_invincibilityLength = 1.5f;
    private float m_invincCounter;

    public float m_flashLength = .3f;
    private float m_flashCounter = 1.5f;

    public SpriteRenderer[] m_playerSprites;

    void Start(){
        m_currentHealth = m_maxHealth;
        UIcontroller.instance.UpdateHealth(m_currentHealth, m_maxHealth);
        
    }
    void Update(){
        if(m_invincCounter>0f)
        {
            //then counter counts down use -=
            m_invincCounter -= Time.deltaTime;
            m_flashCounter -= Time.deltaTime;
            if(m_flashCounter <=0)
            {
                foreach(SpriteRenderer sr in m_playerSprites){
                    sr.enabled = !sr.enabled;
                }
                m_flashCounter = m_flashLength;

                
            }
            if(m_invincCounter <=0)
            
                foreach(SpriteRenderer sr in m_playerSprites)
                {
                sr.enabled = true;
            }
            m_flashCounter=0;
        }
    }
   public void DamagePlayer(int p_damageAmount){
       if(m_invincCounter<=0)
        {

            
            //rules of damage 
            m_currentHealth -= p_damageAmount;
            
            if(m_currentHealth<=0)
            {
                //important trial error if this line is not here
                //you get a -value if your player was at 2 and 4 was taken then -2
                //so we have to reset to 0 if interger scale below 0
                m_currentHealth = 0;

                gameObject.SetActive(false);
                //Destroy(gameObject);
            }else
            {
                //set the counter 
                m_invincCounter = m_invincibilityLength;


            }
            UIcontroller.instance.UpdateHealth(m_currentHealth, m_maxHealth);
        }
   }


}
