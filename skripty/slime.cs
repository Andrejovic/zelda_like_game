using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : enemy
{
    public Transform target;
    public float chaseRange;
    public float attackRange;
    public Transform homePos;
    private Rigidbody2D body;
    private Animator animator;
    private float currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        body = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        currentHealth = GetComponent<enemy>().maxHealth.initialValue;
        animator.SetFloat("health", currentHealth);
        animator.SetFloat("moveX", Random.Range(0.0f, 1.0f));
        animator.SetFloat("moveY", Random.Range(0.0f, 1.0f));
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        animator.SetFloat("health", GetComponent<enemy>().health);
       
    }
    
    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRange && 
                            Vector3.Distance(target.position, transform.position) > attackRange)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                animator.SetBool("moving" , true);
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                body.MovePosition(temp);
                ChangeState(EnemyState.walk);
                animator.SetFloat("moveX" , target.position[0]-temp[0]);
            }
        }
        else
        {
            animator.SetBool("moving" , false);
        }
    }
    
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
