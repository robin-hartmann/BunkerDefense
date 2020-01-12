using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTarget : MonoBehaviour
{
    public float health;

    private void OnCollisionStay(Collision collision)
    {
        DamageSource damageSource = collision.gameObject.GetComponent<DamageSource>();

        if (damageSource == null)
        {
            return;
        }
        
        health -= damageSource.damagePerTimeUnit * Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }
    }
}
