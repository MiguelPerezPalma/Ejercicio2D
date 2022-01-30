using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathZone : MonoBehaviour
{
    private Transform player;
    private Transform respawnpoint;
    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Pies"){
            SceneManager.LoadScene("Muerte");
        }
        if(other.tag=="Enemy"){
            Destroy(other.gameObject);
        }
            
            
        
    }
    
}
