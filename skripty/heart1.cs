using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartConUp : powerup
{
    public floatValue playerHealth;
    public floatValue heartCons;
    public float increaseH;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            playerHealth.RuntimeValue += increaseH;
            heartCons.RuntimeValue += increaseH/2;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
