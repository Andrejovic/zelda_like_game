using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class click_change : MonoBehaviour
{
    public floatValue health;
    public floatValue healthCon;
    public floatValue damage;
    
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        if (health != null)
        {
            health.RuntimeValue = health.initialValue;
        }
        if (healthCon != null)
        {
            healthCon.RuntimeValue = healthCon.initialValue;
        }
        if (damage != null)
        {
            damage.RuntimeValue = damage.initialValue;
        }
    }
}
