using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator; 
    private bool puedoSaltar = false;

    //bullet
    public GameObject ball;
    public GameObject leftball;
    public GameObject MediumBullet;
    public GameObject MediumBulletLeft;
    public GameObject BigBullet;
    public GameObject BigBulletLeft;

    private float time = 0f;
    private float BulletTime = 0;
    private float MediumBulletTime = 3f;
    private float BigBulletTime = 5f;

    //COLOR
    private float switchColorDelay = .1f;
    private float switchColorTime = 0f;
    private Color originalColor;


    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
      rb2d = GetComponent<Rigidbody2D>(); 
      animator = GetComponent<Animator>();
      originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {    
        SetIdleAnimation();
        if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            SetIRunShootAnimation();
            rb2d.velocity = new Vector2(10, rb2d.velocity.y);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            SetIRunShootAnimation();
            rb2d.velocity = new Vector2(-10, rb2d.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && puedoSaltar)
        {
            var jump = 80f;
            SetJumpAnimation();
            rb2d.velocity = Vector2.up * jump;
            puedoSaltar = false;
        }
        if(Input.GetKey(KeyCode.X))
        {
            time += Time.deltaTime; 
            Debug.Log("El tiempo es de: " + time);
            cambioColor(); 
        }        
        if(Input.GetKeyUp(KeyCode.X))
        {
            if(time >= BulletTime)
            {         
                if(!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.6f, transform.position.y + .2f);
                    Instantiate(ball,position,ball.transform.rotation);
                }
                else
                {
                    var position = new Vector2(transform.position.x - 1.6f, transform.position.y + .2f);
                    Instantiate(leftball,position,leftball.transform.rotation);
                }
            }            
            if(time >= MediumBulletTime)
            { 
                if(!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.6f, transform.position.y + .2f);
                    Instantiate(MediumBullet,position,ball.transform.rotation);
                }
                else
                {
                    var position = new Vector2(transform.position.x - 1.6f, transform.position.y + .2f);
                    Instantiate(MediumBulletLeft,position,leftball.transform.rotation);
                }         
            }            
            if(time >= BigBulletTime)
            { 
                if(!sr.flipX)
                {
                    var position = new Vector2(transform.position.x + 1.6f, transform.position.y + .2f);
                    Instantiate(BigBullet,position,ball.transform.rotation);
                }
                else
                {
                    var position = new Vector2(transform.position.x - 1.6f, transform.position.y + .2f);
                    Instantiate(BigBulletLeft,position,leftball.transform.rotation);
                }         
            }
            time = 0;             
        }         
    }
    private void SwitchColor()
    {
        if(sr.color == originalColor)
            sr.color = Color.red;
        else
            sr.color = originalColor;
            switchColorTime = 0;
        
    }
    private void cambioColor(){
     switchColorTime += Time.deltaTime;
        if (switchColorTime > switchColorDelay)
        {
            SwitchColor();
        } 
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        puedoSaltar = true;
    }
    private void SetIdleAnimation()
    {
        animator.SetInteger("Estado",0);

    }
    private void SetRunAnimation()
    {
        animator.SetInteger("Estado",1);

    }    
    private void SetJumpAnimation()
    {
        animator.SetInteger("Estado",2);

    }
    private void SetIRunShootAnimation()
    {
        animator.SetInteger("Estado",3);

    }
}
