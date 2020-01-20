using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Vector3 targetPosition;
    public float triggerDistance;
    public float movementSpeed;
    public GameObject explosion;

    private void Start()
    {
        transform.LookAt(targetPosition);
    }

    void Update()
    {
        BoxCollider collider = gameObject.GetComponent<BoxCollider>();

        if (!collider.enabled)
        {
            return;
        }

        if (Vector3.Distance(transform.position, targetPosition) <= triggerDistance)
        {
            collider.enabled = false;
            GameManager.GameOver(gameObject, explosion);
            return;
        }

        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
