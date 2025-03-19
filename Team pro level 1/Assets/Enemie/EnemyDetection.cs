using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    static public bool found = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "soldier")
        {
            print("SoldierMovement Detected");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        found = false;
    }
}
