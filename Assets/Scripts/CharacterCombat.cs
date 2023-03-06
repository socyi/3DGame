using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public GameObject FloatingTextPrefab3;

    public float attackCooldown;

    public CharacterStats myStats;

    bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        if(canAttack == false)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
                canAttack = true;
        }
    }

    public void MeleeAttack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            targetStats.TakeDamage(myStats.damage, FloatingTextPrefab3);
            attackCooldown = 1 / myStats.attackSpeed;
            canAttack = false;
        }
    }
    
}
