using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : powerup
{
    public floatValue playerHealth;
    public floatValue heartCons;
    public float increaseH;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            playerHealth.RuntimeValue += increaseH;
            if (playerHealth.RuntimeValue > heartCons.RuntimeValue * 2)
            {
                playerHealth.RuntimeValue = heartCons.RuntimeValue * 2;
            }
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
