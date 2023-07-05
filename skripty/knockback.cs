using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knockback : MonoBehaviour
{
    public floatValue damage;
    public float thrust;
    public float knockTime;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("boss"))
        {
            Rigidbody2D body = col.GetComponent<Rigidbody2D>();
            if (body != null)
            {
                Vector2 difference = body.transform.position - transform.position;
                difference = difference.normalized * thrust;
                body.AddForce(difference, ForceMode2D.Impulse);
                
                if((col.gameObject.CompareTag("enemy") || col.gameObject.CompareTag("boss")) && col.isTrigger && this.gameObject.CompareTag("PlayerHit"))
                {
                    body.GetComponent<enemy>().currentState = EnemyState.stagger;
                    col.GetComponent<enemy>().Knock(body, knockTime, damage.RuntimeValue);
                }
                if(col.gameObject.CompareTag("Player"))
                {
                    if(col.GetComponent<player_input>().currentState != PlayerState.stagger)
                    {
                        body.GetComponent<player_input>().currentState = PlayerState.stagger;
                        col.GetComponent<player_input>().Knock(knockTime, damage.RuntimeValue);
                    }
                }
                
            }
        } 
    }
}
