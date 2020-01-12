using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 targetPosition;
    public float triggerDistance;
    public float movementSpeed;

    private void Start()
    {
        transform.LookAt(targetPosition);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) <= triggerDistance)
        {
            Destroy(gameObject);
            return;
        }

        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
