using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void ReduceHealth(float n)
    {
        health -= n;
        if (health <= 0f)
            Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
