using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    private EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        //Si es un jabon
        if (other.gameObject.TryGetComponent(out SoapController soapController))
        {
            enemyHealth.ReduceHealth(soapController.soapWeaponScriptable.damage);

        }

        Destroy(other.gameObject);
    }

}
