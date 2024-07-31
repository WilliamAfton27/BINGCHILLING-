using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame!!! :()
    void Update()
    {
        Agent.SetDestination(Target.position);
    }
}
