using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterComponents : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public Transform ShootPoint;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    public GameObject Bullet;
    public int defaultAdditionalJumps = 1;
    int additionalJumps;
    public bool facingRight;
    public int health;
    public int maxHealth=100;
    public bool dead = false;
    public int coin = 0;
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        dead = false;
        //Bullet = GameObject.FindGameObjectWithTag("Bullet");
        facingRight = true;
        additionalJumps = defaultAdditionalJumps;
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor || additionalJumps > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            additionalJumps--;
        }
    }
    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetAxis("Horizontal") < 0 && facingRight || Input.GetAxis("Horizontal") > 0 && !facingRight)
        {
            changingDirection();
        }

        float moveBy = x * speed;

        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    public virtual void changingDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
    public void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (colliders != null)
        {
            isGrounded = true;
            additionalJumps = defaultAdditionalJumps;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
        
    }
    public void AttackHandler()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            shoot();    
        }
    }
    public void shoot()
    {
        if (facingRight)
        {
            GameObject tmp = (GameObject)Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, -90)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.right);
        }
        else
        {
            GameObject tmp = (GameObject)Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 90)));
            tmp.GetComponent<Bullet>().Initialize(Vector2.left);
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void check()
    {
        if (health <= 0)
        {
            Debug.Log("dead");
            health = 0;
            dead = true;

        }
        if (health > 100)
        {
            health = maxHealth;
        }
        
    }
}
