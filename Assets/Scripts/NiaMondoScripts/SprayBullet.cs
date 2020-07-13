using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayBullet : MonoBehaviour
{
    [HideInInspector]
    public  float velocity;
    private float incr;

    [HideInInspector]
    public float dir;
    // Start is called before the first frame update

    void Start()
    {
        ParticleSystem pSystem =  GetComponent<ParticleSystem>();
        pSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(dir == 1)
        incr = 1;
        else 
        incr = 2;
       // transform.Translate(new Vector2((velocity+incr)*dir, 0) *Time.deltaTime );
        transform.Translate( velocity*transform.right * Time.deltaTime);

    }
}
