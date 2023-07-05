using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateToBoss : MonoBehaviour
{
    public GameObject player;
    public bool inRange;
    public AudioSource myAudio;
    public AudioClip bossSound;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            player.transform.position = new Vector3(-46.5f,21,-0.3064f);
            myAudio.Stop();
            myAudio.clip = bossSound;
            myAudio.Play();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            inRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
