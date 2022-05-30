using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyingController : MonoBehaviour
{
    //when enemy range is X distance from Y it goes in vector2d toward and anim activates.
    public float m_rangeStartChase;
    //keep track if chasing
    private bool m_isChasing;
    public float m_moveSpeed, m_turnSpeed;

    private Transform m_target;
    public Animator m_anim;

    void Start(){
        //note wher is the data of trasnform acquired how can you get data?
        //trasnform on player? or any object on player?
        //notivce instead of GetComponent<> we are getting instance from player script of singleton pattern.

        m_target = PlayerHealthController.s_instance.transform;
    }
    void Update(){
        if(!m_isChasing){
            if(Vector3.Distance(transform.position, m_target.position) < m_rangeStartChase){
                m_isChasing = true;
                m_anim.SetBool("ischasing", m_isChasing);
            }
        }
        else{
            if(m_target.gameObject.activeSelf){
                Vector3 l_direction = transform.position - m_target.position;
                float l_angle = Mathf.Atan2(l_direction.y, l_direction.x) * Mathf.Rad2Deg;

                Quaternion l_targetRot = Quaternion.AngleAxis(l_angle, Vector3.forward);

                transform.rotation=Quaternion.Slerp(transform.rotation, l_targetRot, m_turnSpeed * Time.deltaTime);
                //transform.position = Vector3.MoveTowards(transform.position, m_target.position, m_moveSpeed * Time.deltaTime);
                transform.position += -transform.right * m_moveSpeed * Time.deltaTime;
            }
        }
    }


}
