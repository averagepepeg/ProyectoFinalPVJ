using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotCombat : MonoBehaviour
{
    public Transform SpawnPoint;

    public float Health = 100;



    //Rifle
    public GameObject player;
    public GameObject bulletPrefab;
    public float bulletSpeed = 3;
    private Animator animator;
    public float animTime = 0.3f;
    private float cooldown = 1f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (animTime <= 0)
        {
            animator.SetBool("IsShooting", false);
            animTime = 0.3f;
        }
        animTime = animTime - Time.deltaTime;
        Fire(cooldown);
    }

    private void Fire( float time)
    {

        if (cooldown <= 0)
        {
            animator.SetBool("IsShooting", true);
            animTime = 0.3f;
            var bullet = Instantiate(bulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = /*SpawnPoint.forward*/ player.transform.position * bulletSpeed;
            cooldown = 1f;
        }
        cooldown = cooldown- Time.deltaTime;
        
    }
}
