using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    Rigidbody2D rb;
    public float spd;
    public float randomDown;
    GameController cont;
   


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cont = FindObjectOfType<GameController>();
        if (spd <= 5)
        {
            Invoke("ballStart", 2f);
        }
       
    }

    private void OnEnable()
    {
        Invoke("ballStart", 2f);
    }

    void ballStart()
    {
        int dir = Random.Range(0, 1);
        if (dir == 0) rb.AddForce(Vector2.down * spd);
        else rb.AddForce(Vector2.up * spd);
        rb.AddForce(Vector2.down * randomDown);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 vel;
            vel.y = rb.velocity.y;
            vel.x = (rb.velocity.x / 2) + (collision.collider.attachedRigidbody.velocity.x / 3);
            rb.velocity = vel;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            cont.HitBrick();
            Destroy(collision.gameObject);
        }
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))// checking to see if bottom floor is hit. bottom is tagged bottom
        {
            cont.loseLife();
            rb.velocity = Vector2.zero; //setting velocity to zero stops ball
            transform.position = new Vector3(0, 0, 0); //set ball position back to zero
            Invoke("ballStart", 2f); //call ballstart function again to push the ball
        }

        
    }
}
