using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int m_totalHealth = 3;
    public GameObject m_deathEffect;

    //method must be called from some event..think about bullet controller before you 
    //write the code since you dont have UML for class and dependencies/composition
    // you are disadvantaged you move forward in syntax without full picture of goal
    //so think "why iws this what is this how is this called before just copypasta...
    public void DamageEnemy(int p_damageAmount){
        //scopeout 1/scopedown1 rules of damage
        m_totalHealth -= p_damageAmount;
        //scopeout 2/scopedown1 conditional is there health?
        if(m_totalHealth <=0)
        //No? Then...test if something for response exist.
        {
            if(m_deathEffect!=null)
            //Not existing?...then make occur where parent/child is on object of class
            {
                Instantiate(m_deathEffect, transform.position, transform.rotation);
            }
            //
            Destroy(gameObject);
        }

    }

}
