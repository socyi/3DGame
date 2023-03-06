using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject dropHP;
    // Start is called before the first frame update
    void Start()
    {
        
        health = 50;
        maxHealth = 50;

        damage = 25;

        attackSpeed = 2f;
    }

    public override void Die()
    {
        Destroy (gameObject, 0f);
        if(dropHP)
            Instantiate(dropHP, transform.position, transform.rotation);
    }
   
}
