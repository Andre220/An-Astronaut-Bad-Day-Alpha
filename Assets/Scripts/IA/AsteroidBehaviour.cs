using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float AsteroidVelocity;
    public GameObject ToFixPrefab;
    public GameObject ExplosionParticle;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameObject.transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), 0, 0);
    }

    void Update()
    {
        if (transform.position.x > 30 || transform.position.x < -30 || transform.position.y > 30 || transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = transform.up * Random.Range(0, 360);

        if (AsteroidVelocity < 0)
        {
            direction = transform.up * Random.Range(0, 180);
        }

        if (AsteroidVelocity > 0)
        {
            direction = transform.up * Random.Range(180, 360);
        }
        
        rb.velocity = direction * Time.fixedDeltaTime * AsteroidVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != null)
        {
            print(collision.gameObject.name);

            if (collision.gameObject.tag == "Spaceship")
            {
                if (collision.gameObject.GetComponent<LifeComponent>() != null)
                {
                    collision.gameObject.GetComponent<LifeComponent>().LifeValue -= 10;
                    //collision.gameObject.GetComponent<LifeComponent>().CurrentMaxLifeValue -= 10;
                };

                Instantiate(ExplosionParticle, gameObject.transform.position, Quaternion.identity);

                Vector3 CollisionPosition = collision.GetContact(collision.contactCount - 1).point;
                Instantiate(ToFixPrefab, CollisionPosition, Quaternion.identity);
            }

            if (collision.gameObject.tag == "Player")
            {
                if (collision.gameObject.GetComponent<LifeComponent>() != null)
                {
                    collision.gameObject.GetComponent<LifeComponent>().LifeValue -= 25;
                    //collision.gameObject.GetComponent<LifeComponent>().CurrentMaxLifeValue -= 25;
                };
            }

            Destroy(gameObject);
        }
    }
}
