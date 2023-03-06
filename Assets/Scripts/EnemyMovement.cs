using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;

    NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance <= navAgent.stoppingDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookDirection, Time.deltaTime * 10f);   
        }

        navAgent.SetDestination(target.position);
    }
}
