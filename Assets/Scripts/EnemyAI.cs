using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent EnemyAgent;
    private State currentState;
    private enum State
    {
        Following,
        Attacking
    }
    private void Awake()
    {
        EnemyAgent.updateRotation = false;
        EnemyAgent.updateUpAxis = false;
        currentState = State.Following;
    }
    private void Start()
    {
        
    }

    private void Following ()
    {
        ChangeFacingDirection();
    }



    private void ChangeFacingDirection(Vector3 targetPosition)
    {
        if()
        {

        }
    }
}
