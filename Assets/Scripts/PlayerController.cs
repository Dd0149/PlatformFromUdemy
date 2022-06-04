
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public Rigidbody2D m_theRB;
   public float m_moveSpeed;
   public float m_JumpForce;
   public Transform m_groundPoint;
   private bool isOnGround;
   public LayerMask whatIsGround;
   public BulletController m_shotToFire;
   public Transform m_shotPoint;

   public Animator m_anim;

   private bool m_canDoubleJump;

   public float m_dashSpeed, m_dashTime;
   private float m_dashCounter; 

   public SpriteRenderer m_theSPR, m_afterImage;
   public float m_afterImageLifeTime, m_timeBetweenAfterImage;
   private float afterImageCounter;
   public Color m_afterImageColor;

   public float m_waitAfterDashing;
   private float m_dashRechargeCounter;

    public GameObject m_standing, m_ballMode;
    public float m_waitToBall;
    private float m_ballCounter;
    public Animator m_ballAnim;

    public Transform m_spolsionPoint;
    public GameObject m_bomb;
    private PlayerAbilityTracker m_abilities;

    public bool m_canMove;
    

    void Start(){
        m_abilities = GetComponent<PlayerAbilityTracker>();
        m_canMove = true;
    }


    void Update()
    {
        
        if(m_canMove)
        {
        
        if(m_dashRechargeCounter>0){
            m_dashRechargeCounter -= Time.deltaTime;
        }
        else
        {

            if(Input.GetButtonDown("Fire2") && m_standing.activeSelf && m_abilities.m_canDash)
            {
                m_dashCounter = m_dashTime;
                ShowAfterImage();
            }
        }
        if(m_dashCounter > 0 )
        {
            m_dashCounter = m_dashCounter - Time.deltaTime;
            m_theRB.velocity = new Vector2(m_dashSpeed * transform.localScale.x, m_theRB.velocity.y);
            afterImageCounter -= Time.deltaTime;
            if(afterImageCounter <= 0)
            {
                ShowAfterImage();
            }
            m_dashRechargeCounter = m_waitAfterDashing;

        }
        

        else
        {
                //move sideways
             m_theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * m_moveSpeed, m_theRB.velocity.y);
                //handle direction change
            if(m_theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else if(m_theRB.velocity.x >0)
            {
                transform.localScale = Vector3.one;
            }
        }
        //checking if on the ground
        isOnGround = Physics2D.OverlapCircle(m_groundPoint.position, .2f, whatIsGround);
        
        //a jump function is given a bool to allow jump in or statement then concatinated is given if to create restricted true/false
        if(Input.GetButtonDown("Jump") && (isOnGround || (m_canDoubleJump) && m_abilities.m_canDoubleJump))
        {
            if(isOnGround)
            {
            m_canDoubleJump = true;
            } else
            {
                m_canDoubleJump = false;
                m_anim.SetTrigger("doubleJump");
            }
             m_theRB.velocity = new Vector2(m_theRB.velocity.x, m_JumpForce);
            
        }


       //shooting 
        if(Input.GetButtonDown("Fire1")){
           if(m_standing.activeSelf){
   
            Instantiate(m_shotToFire, m_shotPoint.position, m_shotPoint.rotation).m_moveDir = new Vector2(transform.localScale.x, 0f);
            m_anim.SetTrigger("isShoot");
                        
           }
           else if(m_ballMode.activeSelf && m_abilities.m_canDropBomb){
               Instantiate(m_bomb, m_spolsionPoint.position, m_spolsionPoint.rotation);
           }

        }

        //Ball mode
        if(!m_ballMode.activeSelf)
        {
           if(Input.GetAxisRaw("Vertical") < -.9f && m_abilities.m_canBecomeBall)
           {
                m_ballCounter -= Time.deltaTime;
                
                if(m_ballCounter<= 0){
                    m_ballMode.SetActive(true);
                    m_standing.SetActive(false);
                }
           }
           else
           {
               m_ballCounter = m_waitToBall;
           }
        
        }
        else
        {
            if(Input.GetAxisRaw("Vertical") > .9f)
           {
                m_ballCounter -= Time.deltaTime;
                
                if(m_ballCounter<= 0){
                    m_ballMode.SetActive(false);
                    m_standing.SetActive(true);
                }
           }
           else
           {
               m_ballCounter = m_waitToBall;
           }
        }
        } else{
            m_theRB.velocity = Vector2.zero;
        }
        if(m_standing.activeSelf){
            m_anim.SetBool("isOnGround", isOnGround);
            m_anim.SetFloat("Speed", Mathf.Abs(m_theRB.velocity.x));
        }
        if(m_ballMode.activeSelf){
            m_ballAnim.SetFloat("Speed", Mathf.Abs(m_theRB.velocity.x));
        }
      


    }

    public void ShowAfterImage(){
        SpriteRenderer image = Instantiate(m_afterImage, transform.position, transform.rotation );
        image.sprite = m_theSPR.sprite;
        image.transform.localScale = transform.localScale;
        image.color = m_afterImageColor;

        Destroy(image.gameObject, m_afterImageLifeTime);
        afterImageCounter = m_timeBetweenAfterImage;
    } 

}
