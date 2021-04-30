using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocityX = 30f;
    private Rigidbody2D rb2d;
    private PlayerController playerController;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector2.right * velocityX;       
    }
}
