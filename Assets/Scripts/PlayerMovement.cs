using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 3;


    private Vector3 direction = Vector3.zero;
    private CharacterController characterController;
    private Animator animator;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (direction == Vector3.zero)
        {
            animator.SetBool("IsWalking", false);
        }
        else 
        {
            animator.SetBool("IsWalking", true);
        }
        characterController.Move(
            //transform.forward * direction.normalized.z * Time.deltaTime * MovementSpeed
            //+ transform.right * direction.normalized.x * Time.deltaTime * MovementSpeed
            direction.normalized * Time.deltaTime * MovementSpeed
        );

    }

    private void OnMove(InputValue value)
    {
        var data = value.Get<Vector2>();
        direction = new Vector3(
            data.x,
            0f,
            data.y
        );
    }

    private void OnFire(InputValue value)
    {
        //animator.SetBool("IsShooting", true);
    }
}
