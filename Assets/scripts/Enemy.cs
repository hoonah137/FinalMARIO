using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed;
    float horizontal = 1;
    Animator anim;
    BoxCollider2D boxCollider;
    Rigidbody2D rBody;
    SFXManager sfxManager;
    SoundManager soundManager;
    GameManager gameManager;
    Transform enemyTransform;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rBody = GetComponent<Rigidbody2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2 (horizontal*speed, rBody.velocity.y);
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
        boxCollider.enabled = false;
        Destroy(this.gameObject, 0.5f);
        sfxManager.MarioDeath();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            float yMario = collision.gameObject.transform.position.y;
            float yMyself = enemyTransform.position.y;
            
            if (yMario > yMyself)
            {
                Debug.Log ("Goomba Muerto");
                Die();
            }
            else
            {
                Debug.Log ("Mario Muerto");
                Destroy(collision.gameObject);
                sfxManager.MarioDeath();
                soundManager.StopBGM();
                gameManager.GameOver();
            }
            
        }   
        else
        {
            if (horizontal == 1)
            {
                horizontal = -1;
            }else 
            {
                horizontal = 1;
            }
        } 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ColisionGoomba")
        {
            if (horizontal == 1)
            {
                horizontal = -1;
            }else 
            {
                horizontal = 1;
            }
        } 
    }

    //Todo lo que sea visible por la camara
    void OnBecameVisible() 
    {
        gameManager.enemiesInScreen.Add(this.gameObject);
    }

    //Todo lo que no este en la vista de la camara
    void OnBecameInvisible() 
    {
        gameManager.enemiesInScreen.Remove(this.gameObject);
    }
}
