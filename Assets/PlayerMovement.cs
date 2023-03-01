using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float JumpInput;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool OnWall = false;
    public GameObject player;
    public float LScaleX = 0;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public AudioSource JumpAudio;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        JumpInput = Input.GetAxisRaw("Vertical");

        /*
                if ((Input.GetKey(KeyCode.W) || Input.GetButtonUp("Jump")) && IsGrounded())
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                }

                if ((Input.GetKey(KeyCode.W) || Input.GetButtonUp("Jump")) && rb.velocity.y > 0f)
                {
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 1.1f);
                }
        */

        if (Input.GetButton("Fire1"))
        {

            Recoil(100);

        }

        if (Input.GetButtonDown("Jump") && (IsGrounded() || (OnWall == true)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            JumpAudio.Play();
            OnWall = false;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            // JumpAudio.Play();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            OnWall = true;
        }
    }
    void OnTriggerExit2D(Collider2D other2)
    {
        if (other2.gameObject.tag == "wall")
        {
            OnWall = false;
        }
    }

    public void Recoil(float recoilForce)
    {
        Debug.Log("Recoil");
        //rb.AddForce(-transform.right * recoilForce, ForceMode2D.Impulse);
        //rb.AddForce(new Vector2(recoilForce, 0f), ForceMode2D.Impulse);

    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            LScaleX = localScale.x;
        }
    }
}