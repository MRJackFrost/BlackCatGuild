using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoviment : MonoBehaviour
{
    public float movespeed;
    public float accelRate;
    private Rigidbody2D rb;
    private SpriteRenderer sp;
    private Animator anim;
    public float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moviment();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
    }

    private void Moviment()
    {
        float hor = Input.GetAxis("Horizontal");
        float desiredSpeed = hor * movespeed;
        float speedDif = desiredSpeed - rb.velocity.x;
        float movement = speedDif * accelRate;
        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        if (hor < 0) sp.flipX = true;
        if (hor > 0) sp.flipX = false;
        if (Mathf.Abs(hor) > 0 ) anim.SetBool("Run", true);
        if (hor == 0) anim.SetBool("Run", false);
    }

    private void jump()
    {
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
