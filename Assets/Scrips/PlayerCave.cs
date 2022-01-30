using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCave : MonoBehaviour
{
    public float velocidadMovimiento=5f; 
    public Rigidbody2D rb;
    public Animator animacion;
    Vector2 movimiento;
    public bool isgrounded;
    public Transform grounded;
    public LayerMask groundlayer;
    private float attacktime=0.40f;
    private float attackcounter=0.40f;
    public float velocidaddesalto=5f;
    Vector2 ataque;
    private bool attaking;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private bool isfacingright=true;
    // Update is called once per frame
    void Update()
    {
        movimiento.x= Input.GetAxisRaw("Horizontal");
        
        
        animacion.SetFloat("Horizontal",movimiento.x);
        animacion.SetFloat("Velocidad",movimiento.sqrMagnitude);
        if(movimiento.x==-1&&isfacingright){
            rb.transform.localScale = new Vector3(-2.277564f,2.107546f,1f);
            isfacingright=false;
        }else if (movimiento.x==1&&!isfacingright){
            rb.transform.localScale = new Vector3(2.277564f,2.107546f,1f);
            isfacingright=true;
        }
    
        if(attaking){
            attackcounter-=Time.deltaTime;
            if(attackcounter<=0){
                rb.velocity=Vector2.zero;
                animacion.SetBool("IsAttacking",false);
                attaking=false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            print("ataca");
            attackcounter=attacktime;
            animacion.SetBool("IsAttacking",true);
            attaking=true;
        }
         if(Input.GetKeyDown(KeyCode.W)&&isgrounded){
          rb.velocity=Vector2.up*velocidaddesalto;
        }
    }
    void FixedUpdate(){
        float xInput= Input.GetAxis("Horizontal");
        float yInput= Input.GetAxis("Vertical");
        transform.Translate(xInput*velocidadMovimiento,yInput*velocidadMovimiento,0);
        rb.velocity=new Vector2(velocidadMovimiento*xInput, rb.velocity.y);
       isgrounded=Physics2D.OverlapCircle(grounded.position,0.2f,groundlayer);
    }
}
