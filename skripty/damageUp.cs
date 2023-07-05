using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageUp : powerup
{
    public floatValue playerDamage;
    public float increaseD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.isTrigger)
        {
            playerDamage.RuntimeValue += increaseD;
            powerupSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
