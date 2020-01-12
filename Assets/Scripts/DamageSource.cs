using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public float damagePerTimeUnit;
    public Material materialOnHit;
    public Material materialOnMiss;

    private Collision lastTargetCollision = null;

    private void Update()
    {
        if (lastTargetCollision == null)
        {
            SetMaterial(materialOnMiss);
        }
        else
        {
            lastTargetCollision = null;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (CollisionIsTarget(collision))
        {
            SetMaterial(materialOnHit);
            lastTargetCollision = collision;
        }
    }

    private bool CollisionIsTarget(Collision collision)
    {
        DamageTarget damageTarget = collision.gameObject.GetComponent<DamageTarget>();

        return damageTarget != null;
    }

    private void SetMaterial(Material material)
    {
        gameObject.GetComponent<Renderer>().material = material;
    }
}
