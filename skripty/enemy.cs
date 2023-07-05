using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack,
    stagger
}

public class enemy : MonoBehaviour
{
    public EnemyState currentState;
    public floatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public AudioSource myAudio;
    public AudioClip bossSound;
    public GameObject winScreen;
    public GameObject prefab;
    private float loot;
    
    private void Awake()
    {
        health = maxHealth.initialValue;
    }
    
    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
            StartCoroutine(DeathCo());
        }
    }
    
    public void Knock(Rigidbody2D body, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(body, knockTime));
        TakeDamage(damage);
    }
    
    private IEnumerator KnockCo(Rigidbody2D body, float knockTime)
    {
        if( body != null)
        {
            yield return new WaitForSeconds(knockTime);
            body.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            body.velocity = Vector2.zero;
        }
    }
    
    private IEnumerator DeathCo()
    {
        
        yield return new WaitForSeconds(0.5f);
        if(this.gameObject.CompareTag("boss"))
        {
            myAudio.Stop();
            myAudio.clip = bossSound;
            myAudio.loop = false;
            myAudio.Play();
            winScreen.SetActive(true);
            winScreen.GetComponent<Animator>().SetBool("boss",true);
            yield return new WaitForSeconds(1f);
        }
        else
        {
            loot=Random.Range(0,1f);
            if(loot >= 0.8f)
            {
                Instantiate(prefab, this.transform.position, Quaternion.identity);
            }
        }
        this.gameObject.SetActive(false);
    }
}
