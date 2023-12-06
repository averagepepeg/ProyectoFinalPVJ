using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RobotCombat : MonoBehaviour
{
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    public Transform SpawnPoint4;
    public Transform SpawnPoint5;
    public Transform SpawnPoint6;
    public Transform SpawnPoint7;
    public Transform SpawnPoint8;

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
            var bullet1 = Instantiate(bulletPrefab, SpawnPoint1.position, SpawnPoint1.rotation);
            bullet1.GetComponent<Rigidbody>().velocity = SpawnPoint1.forward * bulletSpeed;

            var bullet2 = Instantiate(bulletPrefab, SpawnPoint2.position, SpawnPoint2.rotation);
            bullet2.GetComponent<Rigidbody>().velocity = SpawnPoint2.forward * bulletSpeed;

            var bullet3 = Instantiate(bulletPrefab, SpawnPoint3.position, SpawnPoint3.rotation);
            bullet3.GetComponent<Rigidbody>().velocity = SpawnPoint3.forward * bulletSpeed;

            var bullet4 = Instantiate(bulletPrefab, SpawnPoint4.position, SpawnPoint4.rotation);
            bullet4.GetComponent<Rigidbody>().velocity = SpawnPoint4.forward * bulletSpeed;

            var bullet5 = Instantiate(bulletPrefab, SpawnPoint5.position, SpawnPoint5.rotation);
            bullet5.GetComponent<Rigidbody>().velocity = SpawnPoint5.forward * bulletSpeed;

            var bullet6 = Instantiate(bulletPrefab, SpawnPoint6.position, SpawnPoint6.rotation);
            bullet6.GetComponent<Rigidbody>().velocity = SpawnPoint6.forward * bulletSpeed;

            var bullet7 = Instantiate(bulletPrefab, SpawnPoint7.position, SpawnPoint7.rotation);
            bullet7.GetComponent<Rigidbody>().velocity = SpawnPoint7.forward * bulletSpeed;

            var bullet8 = Instantiate(bulletPrefab, SpawnPoint8.position, SpawnPoint8.rotation);
            bullet8.GetComponent<Rigidbody>().velocity = SpawnPoint8.forward * bulletSpeed;
            cooldown = 1f;
        }
        cooldown = cooldown- Time.deltaTime;
        
    }
}
