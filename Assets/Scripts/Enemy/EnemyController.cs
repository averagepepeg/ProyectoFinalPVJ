using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR.Haptics;

[RequireComponent(typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    public IdleState IdleState;
    public FollowState FollowState;
    private State currentState;

    public float timer = 0;
    public Transform Player;
    public float DistanceToFollow = 4f;
    public float DistanceToAttack = 1f;
    public float Speed = 1f;

    public float Health = 100f;
    public float DamageRecived = 0f;


    public Rigidbody rb {  get; private set; }
    public Animator animator { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public CapsuleCollider coll;
    private GameObject self;

    
    private void Awake()
    {
        IdleState = new IdleState(this);
        FollowState = new FollowState(this);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        coll = GetComponent<CapsuleCollider>();
        self = this.gameObject;

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

        if (Health <= 0f)
        {
            Destroy(self);
        }
        //Debug.Log(Health);
        //Debug.Log(DamageRecived);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            DamageRecived = 35f;
            Health -= DamageRecived;
        }
        if (collision.gameObject.tag == "Player")
        {
            var healthComponent = collision.gameObject.GetComponent<Health>();
            if (healthComponent != null) 
            {
                healthComponent.TakeDamage(10);
            }
        }
        //Debug.Log(collision.gameObject.tag);
    }



}
