using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierY : enemy
{
    public Transform target;
    public float chaseRange;
    public float attackRange;
    public Transform homePos;
    private Rigidbody2D body;
    private Animator animator;
    private float currentHealth;
    public int y;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        body = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = GetComponent<enemy>().maxHealth.initialValue;
        animator.SetFloat("health", currentHealth);
        animator.SetFloat("moveY", y);
        animator.SetBool("y", true);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        animator.SetFloat("health", GetComponent<enemy>().health);
       
    }
    
    void CheckDistance()
    {
        if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
        {
            Vector3 temp = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0,y,0), moveSpeed * Time.deltaTime);
            body.MovePosition(temp);
            ChangeState(EnemyState.walk);
            animator.SetFloat("moveY" , y);
        }
        
    }
    
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        y *= -1;
    }
}
