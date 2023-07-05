using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] Health;
    public Sprite fullH;
    public Sprite halfH;
    public Sprite emptyH;
    public floatValue HeartCon;
    public floatValue currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }
    
    public void InitHearts()
    {
        if(HeartCon != null)
        {
            for (int i = 0; i < HeartCon.RuntimeValue; i++)
            {
                Health[i].gameObject.SetActive(true);
                Health[i].sprite = fullH;
            }
        }
    }
    
    public void UpdateHearts()
    {
        InitHearts();
        float tempHealth = currentHealth.RuntimeValue / 2;
        for (int i = 0; i < HeartCon.RuntimeValue; i++)
        {
            if(i <= tempHealth - 1 )
            {
                Health[i].sprite = fullH;
            }
            else if( i >= tempHealth)
            {
                Health[i].sprite = emptyH;
            }
            else
            {
                Health[i].sprite = halfH;
            }
        }
    }
}
