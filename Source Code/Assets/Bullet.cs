using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
	[SerializeField]
    public float speed=10;
    public Rigidbody2D myrigidbody;
	
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();   
    }
    private void FixedUpdate()
    {
        myrigidbody.velocity = direction * speed;
        Destroy(gameObject, 2f);
    } 
    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Destroy(gameObject);
            Destroy(collision.gameObject);
            //enemy.TakeDamage(damage);
        }
    }
}
