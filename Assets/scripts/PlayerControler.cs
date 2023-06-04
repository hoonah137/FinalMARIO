using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float playerSpeed = 5.5f;

   string text = "Hello world";

   public SpriteRenderer sRender ;

   float horizontal;

   Rigidbody2D rBody; 

   public float jumpForce = 5.7f;

   GroundSensor sensor;

   public Animator anim; 

    void Start()
    {
        //definir atributos para poder utilizarlos posteriormente

        sRender = GetComponent<SpriteRenderer> ();

        rBody = GetComponent<Rigidbody2D>();

        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();

        anim = GetComponent<Animator>();

        Debug. Log(text);


        //GameObject.find = encuentra objetos por su nombre propio

        
    }

    // Update is called once per frame
    void Update()
    {
      
      //atributo horizontal
      horizontal = Input . GetAxis("Horizontal");


      if (horizontal < 0 )
      {
        sRender.flipX = true;
        anim.SetBool("IsRunning", true);
      }

      else if (horizontal > 0 )
      {
        sRender.flipX = false;
       anim.SetBool("IsRunning", true);

      }

      else 
      { 
         anim.SetBool("IsRunning", false);

      }

      if(Input.GetButtonDown("Jump") && sensor.isGrounded) 
      {
        //vector2 se refiere a un parametro transform
        //forcemode2d es un componente propio de unity que cre una fuerza artificial
        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("IsJumping", true);
      }
    }

     public void FixedUpdate() 
    {
      rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }
}
