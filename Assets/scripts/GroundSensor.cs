using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundSensor : MonoBehaviour
{
    private PlayerControler controller;
    public bool isGrounded;

    SFXManager sfxManager;
    SoundManager soundManager;
    GameManager gameManager;

    private void Awake() {
        controller = GetComponentInParent<PlayerControler>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = true;     
         controller.anim.SetBool("IsJumping", false);
        } else if(other.gameObject.layer==6)
        {
            Debug.Log("Goomba muerto");
            sfxManager.GoombaDeath();
            Enemy goomba = other.gameObject.GetComponent<Enemy>();
            goomba.Die();
        }
        else if(other.gameObject.tag == "coin")
        {
            Debug.Log("Mario collides coin");
            
            Coin coin = other.gameObject.GetComponent<Coin>();
            coin.Pick();
        }
        if(other.gameObject.tag == "DeadZone"){
            Debug.Log("Estoy muerto");
            sfxManager.MarioDeath();
            soundManager.StopBGM();
            gameManager.GameOver();
        }

    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
          isGrounded = true;     
          controller.anim.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = false;
         controller.anim.SetBool("IsJumping", true);     
        }
    }
}
