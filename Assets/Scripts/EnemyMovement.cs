using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private NavMeshAgent agent;

    private Transform player;

    #endregion

    #region Methods

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        agent.SetDestination(player.position);
    }

    #endregion
}
