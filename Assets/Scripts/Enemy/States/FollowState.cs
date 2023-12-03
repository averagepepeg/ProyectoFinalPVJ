using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public FollowState(EnemyController controller) : base(controller)
    {
        //Transition Follow -> Idle
        Transition transitionFollowToIdle = new Transition
            (
                isValid: () =>
                {
                     float distance = Vector3.Distance(controller.Player.position, controller.transform.position);
                     if (distance >= controller.DistanceToFollow)
                     {
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                },
                getNextState: () =>
                {
                    return new IdleState(controller);
                }
             );
        Transitions.Add(transitionFollowToIdle);

        //Transition Follow -> Attack
        Transition transitionFollowToAttack = new Transition
            (
                isValid: () =>
                {
                    float distance = Vector3.Distance(controller.Player.position, controller.transform.position);
                    if (distance <= controller.DistanceToAttack)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                },
                getNextState: () =>
                {
                    return new AttackState(controller);
                }
            );
        Transitions.Add(transitionFollowToAttack);
    }

    public override void OnStart()
    {
        //Debug.Log("Estado Follow:Start");
        controller.agent.isStopped = false;
        controller.agent.velocity = new Vector3(controller.Speed,0f,controller.Speed);
        controller.animator.SetBool("IsWalking", true);
    }
    public override void OnUpdate()
    {
        //Rotar al enemigo para que mire al jugador
        var dir = controller.Player.position - controller.transform.position;
        var desiredRotation = Quaternion.LookRotation(dir);
        controller.transform.rotation = Quaternion.Lerp(controller.transform.rotation, desiredRotation, 0.1f);

        //Mover al enemigo
        controller.agent.destination = controller.Player.position;

       // Debug.Log(Vector3.Distance(controller.Player.position, controller.transform.position));
    }
    public override void OnFinish()
    {
        Debug.Log("Estado Follow: Finish");
        controller.animator.SetBool("IsWalking", false);
    }
}
