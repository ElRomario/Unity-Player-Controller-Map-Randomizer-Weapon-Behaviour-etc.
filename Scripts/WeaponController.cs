using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [Header("Weapon Stats")]
    public GameObject prefab;
    public float speed;
    public float damage;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;
    Vector2 playeStopPosition = new(0,0);


    protected static PlayerMovement playerMovemnet;

    protected virtual void Start()
    {
        playerMovemnet = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDuration;
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f && Input.GetMouseButton(0) && playerMovemnet.rb.velocity != playeStopPosition)
        {
            Attack();
        }
        
    }
    protected virtual void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
