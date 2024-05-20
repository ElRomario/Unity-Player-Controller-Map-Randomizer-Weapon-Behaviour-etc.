using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Knife"))
        {
            Debug.Log($"Collusin with{other.name}");
            Destroy(gameObject);
        }
    }

}
