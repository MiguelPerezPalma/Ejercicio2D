using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    public float velocidadMovimiento=5f; 
    public Rigidbody2D rb;
    public Animator animacion;
    Vector2 movimiento;
    Vector2 ataque;
    private float attacktime=0.25f;
    private float attackcounter=0.25f;
    private bool attaking;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animacion=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.x= Input.GetAxisRaw("Horizontal");
        movimiento.y= Input.GetAxisRaw("Vertical");
        animacion.SetFloat("Horizontal",movimiento.x);
        animacion.SetFloat("Verical",movimiento.y);
        animacion.SetFloat("velocidad",movimiento.sqrMagnitude);
        
        
        
        
        if(attaking){
            attackcounter-=Time.deltaTime;
            if(attackcounter<=0){
                rb.velocity=Vector2.zero;
                animacion.SetBool("isAttaking",false);
                attaking=false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            print("ataca");
            attackcounter=attacktime;
            animacion.SetBool("isAttaking",true);
            attaking=true;
        }
        if(Input.GetAxisRaw("Horizontal")>=1||Input.GetAxisRaw("Horizontal")<=-1||Input.GetAxisRaw("Vertical")>=1||Input.GetAxisRaw("Vertical")<=-1){
            animacion.SetFloat("UltMovHoriz",Input.GetAxisRaw("Horizontal"));
            animacion.SetFloat("UltMovVert",Input.GetAxisRaw("Vertical"));
        }
    }

   void FixedUpdate(){
        rb.MovePosition(rb.position+movimiento*velocidadMovimiento*Time.fixedDeltaTime);
        
    }
    public void OnTriggerEnter2D(Collider2D other){
       
            if(other.tag=="Enemy"){
                Destroy(other.gameObject);
               
            
        }
        
    }

}
