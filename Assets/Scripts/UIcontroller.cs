using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance;
    private void Awake(){
        if(instance == null){
        instance=this;
        DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
    }
    void Start(){
       
    }
    public Slider m_healthSlider;
    public Image fadeScreen;
    public float m_fadeSpeed = 2f;
    private bool m_fadeToBlack, m_fadingFromBlack;

    void Update(){

        if(m_fadeToBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, m_fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f ){
                m_fadeToBlack = false;
            }
        }else if(m_fadingFromBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, m_fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 0f ){
                m_fadingFromBlack = false;
            }
        }

    }
    public void StartFadeToBlack(){
        //this is a bad way to make a from/to toggle switch but that is how is is envisioned as on/off
        m_fadeToBlack = true;
        m_fadingFromBlack = false;
    }
    public void StartFadeFromBlack(){
        m_fadingFromBlack = true;
        m_fadeToBlack = false;
        
    }

    public void UpdateHealth(int m_currentHealth, int m_maxHealth){
        m_healthSlider.maxValue = m_maxHealth;
        m_healthSlider.value = m_currentHealth;
    }

}
