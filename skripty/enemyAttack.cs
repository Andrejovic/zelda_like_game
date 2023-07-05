using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;
    public float timeRange;
    public float speed;
    private Vector3 change;
    public bool AttackDone;
    private Transform where;
    
    void Start()
    {
        
        AttackDone = true;
    }
   
   

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<enemy>().health!=0)
        {
            projectile.transform.position = Vector3.MoveTowards(projectile.transform.position, projectile.transform.position + new Vector3(0,-1,0) , speed * Time.deltaTime);
            if (AttackDone)
            {
                AttackDone = false;
                StartCoroutine(EnemyAttackCo());
            }
        }
    }
    
    private IEnumerator EnemyAttackCo()
    {
        projectile.transform.position = firePosition.position;
        projectile.SetActive(true);
        yield return new WaitForSeconds(Random.Range(timeRange,timeRange+2));
        projectile.SetActive(false);
        AttackDone = true;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("collision"))
        {
            projectile.SetActive(false);
            AttackDone = true;
        }
    }
}
