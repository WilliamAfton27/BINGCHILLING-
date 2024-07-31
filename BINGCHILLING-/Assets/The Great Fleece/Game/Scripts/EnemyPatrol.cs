using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> patrolPoints; // List of patrol points
    private int currentPatrolIndex;
    private NavMeshAgent navMeshAgent;
    public float patrolPointReachedThreshold = 0.5f; // Threshold distance to reach a patrol point

    public Animator animator; // Reference to the Animator component
    public AnimationClip startMovingAnimation; // Start moving animation clip
    public AnimationClip stopMovingAnimation; // Stop moving animation clip

    private bool isMoving = false; // Track whether the object is currently moving
    private bool isWaiting = false; // Track whether the object is waiting

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Count > 0)
        {
            currentPatrolIndex = 0;
            navMeshAgent.SetDestination(patrolPoints[0].position);
            PlayStartMovingAnimation();
        }
    }

    void Update()
    {
        if (isWaiting) return;

        bool wasMoving = isMoving;
        isMoving = navMeshAgent.velocity.sqrMagnitude > 0.01f;

        if (isMoving && !wasMoving)
        {
            PlayStartMovingAnimation();
        }
        else if (!isMoving && wasMoving)
        {
            PlayStopMovingAnimation();
        }

        // Check if the enemy has reached the current patrol point
        if (Vector3.Distance(transform.position, patrolPoints[currentPatrolIndex].position) < patrolPointReachedThreshold)
        {
            StartCoroutine(WaitAtCheckpoint());
        }
    }

    IEnumerator WaitAtCheckpoint()
    {
        isWaiting = true;
        PlayStopMovingAnimation();
        navMeshAgent.isStopped = true;

        yield return new WaitForSeconds(2);

        navMeshAgent.isStopped = false;
        // Move to the next patrol point
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
        navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex].position);
        PlayStartMovingAnimation();
        isWaiting = false;
    }

    void PlayStartMovingAnimation()
    {
        if (animator != null && startMovingAnimation != null)
        {
            animator.Play(startMovingAnimation.name);
        }
    }

    void PlayStopMovingAnimation()
    {
        if (animator != null && stopMovingAnimation != null)
        {
            animator.Play(stopMovingAnimation.name);
        }
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
