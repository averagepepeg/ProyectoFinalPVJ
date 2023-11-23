using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public IdleState IdleState;
    public FollowState FollowState;
    private State currentState;

    public Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 3f;
    public float Speed = 1f;

    public Rigidbody rb {  get; private set; }
    public Animator animator { get; private set; }
    public NavMeshAgent agent { get; private set; }
    

    
    private void Awake()
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        currentState = IdleState;
    }

    private void Start()
    {
        currentState.OnStart();
    }

    private void Update()
    {
        foreach (var transition in currentState.Transitions)
        {
            if (transition.IsValid())
            {
                currentState.OnFinish();
                currentState = transition.GetNextState();
                currentState.OnStart();
                break;
            }
        }
        currentState.OnUpdate();
    }

}
