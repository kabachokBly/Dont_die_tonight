using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private float attackingDistance = 5f;

    private State _currentState;
    private const string IS_ATTAKING = "IsAttacking";
    private enum State
    {
        Following,
        Attacking
    }
    private void Awake()
    {
        enemyAgent.updateRotation = false;
        enemyAgent.updateUpAxis = false;
        _currentState = State.Following;
    }
    private void Update()
    {
        ChangeFacingDirection();
        StateHandler();
    }
    private void StateHandler()
    {
        if (_currentState == State.Following)
        {
            Following();
        }
        else
        {

        }
    }
    private void Following()
    {
        enemyAgent.SetDestination(Player.Instance.transform.position);

    }



    private void ChangeFacingDirection()
    {
        Debug.Log(enemyAgent.velocity.normalized.x);
        if (enemyAgent.velocity.normalized.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
