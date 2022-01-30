using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScrip : MonoBehaviour
{
    private Animator animacion;
    private Transform objetivo;
    public float velocidad;
    public float rango;
    void Start()
    {
        
        animacion=GetComponent<Animator>();
        objetivo=FindObjectOfType<PlayerScrip>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        persigue();
    }
    public void persigue(){
        animacion.SetBool("IsMoving",true);
        animacion.SetFloat("Horizontal",objetivo.position.x-transform.position.x);
        animacion.SetFloat("Verical",objetivo.position.y-transform.position.y);
        transform.position=Vector3.MoveTowards(transform.position,objetivo.transform.position,velocidad*Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D other){
       
            if(other.tag=="Player"){
                animacion.SetBool("IsAttacking",true);
                SceneManager.LoadScene("Muerte");
               
        }else{
            animacion.SetBool("IsAttacking",false);
        }
        
    }
    
}
