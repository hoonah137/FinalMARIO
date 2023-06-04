using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D boxCollider;
    Animator anim;
    SFXManager sfxManager;
    SoundManager soundManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void Pick()
    {
        anim.SetBool("Giro Moneda", false);
        boxCollider.enabled = false;
        Destroy(this.gameObject);
        soundManager.SoundCoin();
    } 

    void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log ("Collision with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log ("Coin picked");
            Pick();
        }   
    }
}
