using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPatrolEnemy : MonoBehaviour
{
    public List<Transform> patrolPoints; // List of patrol points
    private NavMeshAgent navMeshAgent;
    private int currentPatrolIndex = -1; // Current patrol point index
    public float patrolPointReachedThreshold = 0.5f; // Threshold to determine if the point is reached
    private Animator animator; // Animation component
    private bool isReactingToCoin = false; // Flag to check if reacting to the coin

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); // Get the animation component
        SetRandomPatrolDestination();
    }

    void Update()
    {
        // Check if the enemy has reached the current patrol point
        if (!isReactingToCoin && Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < patrolPointReachedThreshold)
        {
            SetRandomPatrolDestination();
        }

        // Set the animation parameter for walking
        animator.SetBool("IsWalking", navMeshAgent.velocity.magnitude > 0.1f);
    }

    void SetRandomPatrolDestination()
    {
        if (isReactingToCoin) return; // Do not change the route if reacting to the coin

        int randomIndex = currentPatrolIndex;
        // Select a random index that is not the current index
        while (randomIndex == currentPatrolIndex)
        {
            randomIndex = Random.Range(0, patrolPoints.Count);
        }
        currentPatrolIndex = randomIndex;

        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    public void ReactToCoin(Vector3 coinPosition)
    {
        // If not already reacting to the coin, set the target position to the coin's position
        if (!isReactingToCoin)
        {
            isReactingToCoin = true;
            navMeshAgent.SetDestination(coinPosition);
            StartCoroutine(ResetReaction());
        }
    }

    private IEnumerator ResetReaction()
    {
        yield return new WaitForSeconds(10.0f); // Time to go to the coin
        isReactingToCoin = false;
        SetRandomPatrolDestination(); // Return to patrolling
    }

    void OnDrawGizmos()
    {
        if (patrolPoints != null && patrolPoints.Count > 1)
        {
            for (int i = 0; i < patrolPoints.Count; i++)
            {
                if (patrolPoints[i] != null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawSphere(patrolPoints[i].position, 0.3f);
                    Gizmos.color = Color.red;
                    if (i < patrolPoints.Count - 1)
                    {
                        Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);
                    }
                    else
                    {
                        Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);
                    }
                }
            }
        }
    }
}
