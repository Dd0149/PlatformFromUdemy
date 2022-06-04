using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///summary: this determines when a health meter is at 0 what to do.
public class RespawnController : MonoBehaviour
{
    
    public static RespawnController instance;
    // Start is called before the first frame update
    
    private void Awake(){
        if(instance == null){
        instance=this;
        DontDestroyOnLoad(gameObject);

        }else{
            Destroy(gameObject);
        }
    }
    private Vector3 m_respawnPoint;
    public float m_waitToRespawn;
    private GameObject m_thePlayer;
    public GameObject m_theDeathEffect;
    
    void Start()
    {
        //this decalres variable assigned to health meter instance
        m_thePlayer = PlayerHealthController.s_instance.gameObject;

        m_respawnPoint = m_thePlayer.transform.position;
    }
     public void SetSpawn(Vector3 newPosition){
        m_respawnPoint = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
    
        
    }

    public void Respawn(){
        //intially you may ask --why not write the code for respawn logic as when and how does this occur?
        //yet in player health controller we already have wehen damage at 0 then do this...so donrt replicate coede.
        StartCoroutine(RespawnCo());

    }

    IEnumerator RespawnCo(){
        m_thePlayer.SetActive(false);
        if(m_theDeathEffect != null){
            Instantiate(m_theDeathEffect, m_thePlayer.transform.position, m_thePlayer.transform.rotation);
        }
        yield return new WaitForSeconds(m_waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_thePlayer.transform.position = m_respawnPoint;
        m_thePlayer.SetActive(true);
        PlayerHealthController.s_instance.FillHealth();

    }
   

}
