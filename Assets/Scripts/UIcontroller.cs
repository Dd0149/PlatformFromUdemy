using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    public static UIcontroller instance;
    private void Awake(){
        instance = this;
    }
    public Slider m_healthSlider;


    public void UpdateHealth(int m_currentHealth, int m_maxHealth){
        m_healthSlider.maxValue = m_maxHealth;
        m_healthSlider.value = m_currentHealth;
    }

}
