using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public Transform SpawnPoint;

    public float Health = 100;




    //Rifle
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    private Animator  animator;
    public float animTime = 0.3f;

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
    }

    private void OnFire(InputValue value) 
    {
        animator.SetBool("IsShooting", true);
        animTime = 0.3f;
        var bullet = Instantiate(bulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = SpawnPoint.forward * bulletSpeed;

    }
}
