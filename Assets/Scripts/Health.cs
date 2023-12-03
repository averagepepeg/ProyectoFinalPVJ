using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    private float iframe = 0.5f;
    private CapsuleCollider col;

    private void Awake()
    {
        anim = GetComponent<Animator>(); 
        col = GetComponent<CapsuleCollider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (iframe <= 0f)
        {
            col.enabled = true;
            iframe = 0.5f;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            anim.SetBool("IsDead", true);
        }
        if (iframe != 0)
        {
            col.enabled = false;
            iframe = iframe - Time.deltaTime;
        }
        col.enabled = false;
        
        
    }
}
