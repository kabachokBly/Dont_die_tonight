using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent enemyAgent;
    [SerializeField] private float attackingDistance = 5f;
    private State _currentState;
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
        StateHandler();
    }
    private void StateHandler()
    {
        if (_currentState == State.Following)
        {

        }
        else
        {

        }
    }
    private void Following()
    {
        enemyAgent.SetDestination(Player.Instance.transform.position);

    }



    //private void ChangeFacingDirection()
    //{
    //    if()
    //    {
    //        transform.rotation = Quaternion.Euler(0, -180, 0);
    //    }
    //    else
    //    {
    //        transform.rotation = Quaternion.Euler(0, 0, 0);
    //    }
    //}
}
