using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Animator m_anim;
    public float m_distanceToOpen;
    //why not just a game object? We want to control animation of player through doorway so access to script enables
    private PlayerController m_thePlayer;

    private bool m_playerExiting;

    public Transform m_exitPoint;
    public float m_exitSpeed;
    public string m_levelToLoad;

    void Start(){
        m_thePlayer = PlayerHealthController.s_instance.GetComponent<PlayerController>();
    }
    void Update(){
        if(Vector3.Distance(transform.position, m_thePlayer.transform.position)<m_distanceToOpen ){
            m_anim.SetBool("DoorOpen", true);

        }else{
            m_anim.SetBool("DoorOpen", false);
        }
        if(m_playerExiting){
            m_thePlayer.transform.position = Vector3.MoveTowards(m_thePlayer.transform.position, m_exitPoint.position, m_exitSpeed * Time.deltaTime);
        }

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(!m_playerExiting){
                //once coroutine starts we want the player not to be able to move so we set to false
                m_thePlayer.m_canMove = false;
                StartCoroutine(UseDoorCo());
            }
        }
    }
    IEnumerator UseDoorCo(){
        m_playerExiting = true ;
        m_thePlayer.m_anim.enabled = false;
        UIcontroller.instance.StartFadeToBlack();

        yield return new WaitForSeconds(2.5f);

        RespawnController.instance.SetSpawn(m_exitPoint.position);
        m_thePlayer.m_canMove = true;
        m_thePlayer.m_anim.enabled = true;

        UIcontroller.instance.StartFadeFromBlack();

        SceneManager.LoadScene(m_levelToLoad);

    }


}
