using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform = null;
    private NavMeshAgent brain = null;

    private void Start()
    {
        brain = this.GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(FindPlayer), 0f, 1f);
    }

    private void FindPlayer()
    {
        brain.SetDestination(playerTransform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.collider.gameObject;

        if (other.CompareTag("Player"))
        {
            Destroy(other);
        }
    }
}