using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AttackState : State
{
    public AttackState(EnemyController controller) : base(controller)
    {
        //Transition Attack -> Follow
        Transition transitionAttackToFollow = new Transition
            (
                isValid: () =>
                {
                    float distance = Vector3.Distance(controller.Player.position, controller.transform.position);
                    if (distance >= controller.DistanceToAttack)
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
                    return new FollowState(controller);
                }
            );
        Transitions.Add( transitionAttackToFollow );
    }

    public override void OnStart()
    {
        Debug.Log("Estado Attack:Start");
        controller.agent.isStopped = true;
    }
    public override void OnUpdate()
    {
        if ( controller.timer == 0 ) 
        {
            controller.animator.SetBool("IsAttacking", true);
        }
        controller.timer = controller.timer + Time.deltaTime;
        if ( controller.timer >= 1.3 ) 
        {
            controller.animator.SetBool("IsAttacking", false);
            controller.timer = 0;
        }
    }
    public override void OnFinish()
    {
        Debug.Log("Estado Attack: Finished");
    }

}
