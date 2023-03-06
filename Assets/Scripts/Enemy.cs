using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    float radius = 2f;
 
    GameObject player;

    public CharacterStats myStats;
    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.player;
        myStats = GetComponent<CharacterStats>();
        navAgent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (Input.GetKeyDown(KeyCode.Space))
        {
          


            if (distance <= radius)
            {
             
                CharacterCombat playerCombat = player.GetComponent<CharacterCombat>();
                if (playerCombat != null)
                    playerCombat.MeleeAttack(myStats);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            myStats.damage *= 5;
            if (distance <= radius)
            {
                CharacterCombat playerCombat = player.GetComponent<CharacterCombat>();
                if (playerCombat != null)
                    playerCombat.MeleeAttack(myStats);
            }
            myStats.damage /= 5;
        }


        else if (Input.GetKeyDown(KeyCode.E))
        {
            myStats.damage *= 4;
            if (distance <= radius)
            {
                CharacterCombat playerCombat = player.GetComponent<CharacterCombat>();
                if (playerCombat != null)
                    playerCombat.MeleeAttack(myStats);
            }
            myStats.damage /= 4;    
        }


        if (distance <= navAgent.stoppingDistance)
        {
            CharacterCombat myCombat = GetComponent<CharacterCombat>();
            CharacterStats playerStats = player.GetComponent<CharacterStats>();
            
            myCombat.MeleeAttack(playerStats);
        }
    }


  

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
