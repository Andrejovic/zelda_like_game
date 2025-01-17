using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    walk,
    attack,
    interact,
    stagger
}

public class player_input : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    public Animator animator;
    public floatValue currentHealth;
    public signalsender playerHealthSignal;
    public AudioSource myAudio;
    public AudioClip deathSound;
    public GameObject deathScreen;

    void Start()
    {
        currentState = PlayerState.walk;
        myAudio = GameObject.Find("Idle Music").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        
    }
    // Update is called once per frame
    void Update()
    {   
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        
        else if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        
    }
    
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.5f);
        currentState = PlayerState.walk;
    }
    
    void UpdateAnimationAndMove(){
        if(!animator.GetBool("dead")){
        if(change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else{
            animator.SetBool("moving", false);
        }
        }
    }
    
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
    
    public void Knock(float knockTime, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCo(knockTime)); 
        }else
        {   
            Death();
            StartCoroutine(KnockCo(knockTime));
        } 
    }
    
    private IEnumerator KnockCo(float knockTime)
    {
        if( myRigidbody != null && myRigidbody.bodyType == RigidbodyType2D.Dynamic)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.walk;
        }
    }
    
    private void Death()
    {
        myAudio.Stop();
        myAudio.clip = deathSound;
        myAudio.loop = false;
        myAudio.Play();
        myRigidbody.bodyType = RigidbodyType2D.Static;
        deathScreen.SetActive(true);
        deathScreen.GetComponent<Animator>().SetBool("dead",true);
        animator.SetBool("dead", true);
    }
}
