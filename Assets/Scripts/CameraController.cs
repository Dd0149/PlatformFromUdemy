using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    private PlayerController m_player;
    public BoxCollider2D m_boundsBox;
    private float m_halfHeigth, m_halfWidth;

    void Start(){
       m_player = FindObjectOfType<PlayerController>();
       //adjusting update function for min max of mathfclamp to insure 
       //when off screen falling the MIN/MAX operator of Clamp has Camera
       //location to move to out of bounds.
       m_halfHeigth = Camera.main.orthographicSize;
       m_halfWidth = m_halfHeigth * Camera.main.aspect;
       
    }
    void Update(){
        //guard clause--if
        // if(m_player == null){
        //     return;
        // }
        if(m_player != null){
            transform.position = new Vector3(
                Mathf.Clamp(m_player.transform.position.x, m_boundsBox.bounds.min.x + m_halfWidth , m_boundsBox.bounds.max.x - m_halfWidth),
                Mathf.Clamp(m_player.transform.position.y, m_boundsBox.bounds.min.y + m_halfHeigth , m_boundsBox.bounds.max.y - m_halfHeigth), 
                transform.position.z);
        }
    }


}
