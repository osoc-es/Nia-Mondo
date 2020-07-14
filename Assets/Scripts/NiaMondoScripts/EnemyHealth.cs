using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private SpriteRenderer sp;


    void Start() {
        sp = GetComponent<SpriteRenderer>();
    }

    public void ReduceHealth(float n)
    {
        health -= n;
        if (health <= 0f)
            Die();
        //sp.enabled = false;
        StartCoroutine(numer());
        //InvokeRepeating("disable", 0.1f, 5); 
    }

    IEnumerator numer() { 
        for(var n = 0; n < 5; n++)
	    {
            sp.enabled = false;
	        yield return new WaitForSeconds(0.1f);
            sp.enabled = true;
	        yield return new WaitForSeconds(0.1f);
	
	
	    }
    }

    void disable() {
        sp.enabled = false;
        Invoke("count",0.1f);
    }

    void count() {
        //yield return new WaitForSeconds(0.2f);
        sp.enabled = true; 
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
