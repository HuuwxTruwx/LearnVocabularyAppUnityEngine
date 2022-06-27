using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoController : MonoBehaviour
{
    public float rayLength;
    public float jumpPower;
    Rigidbody2D rb;
    Animator animator;
    public bool jump;
    public bool die = false;
    public Game1CheckAnwer game1;
    public GameObject block;

    // Start is called before the first frame update

    private void Start()
    {
        game1 = GameObject.Find("Game1").GetComponent<Game1CheckAnwer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.up, Vector3.right, rayLength, LayerMask.GetMask("Block"));
        if(hit.collider != null && jump)
        {        
            rb.AddForce(Vector2.up * jumpPower);
            
           
        }
        Debug.DrawRay(transform.position + Vector3.up, Vector3.right * rayLength, Color.red);

        if(rb.velocity.y < -1)
        {
            rb.velocity -= new Vector2(rb.velocity.x, 1);
        }
   
    }

    public void SetAnimationState()
    {
        animator.SetBool("SpeedUp", true);
        Destroy(block);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            game1.question.SelectQuestion();
            game1.DisPlayAnswer();
            animator.SetBool("OnGround", true);
            jump = false;

        }

        if (collision.gameObject.CompareTag("Block"))
        {       
            die = true;
            animator.SetBool("Died", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity += new Vector2(rb.velocity.x, 2);
            animator.SetBool("OnGround", false);
        }
    }
}
