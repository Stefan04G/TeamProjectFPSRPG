using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    bool TurnToSoldier = false;
    public GameObject soldier;
    Rigidbody rb;
    public float speed = 10f;
    public float multiplier = 10f;
    public float max_speed = 8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (EnemyDetection.found)
        {
            //enemy turns towards soldier
            TurnToSoldier = true;
        }

        if (TurnToSoldier)
        {
            transform.LookAt(soldier.transform);
            Vector3 velocity = rb.velocity;
            if (!EnemyDetection.found && velocity.x >-2f && velocity.x <2f && velocity.z >-2f && velocity.z <2f)
            {
                rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
            }

        }
    }
}
