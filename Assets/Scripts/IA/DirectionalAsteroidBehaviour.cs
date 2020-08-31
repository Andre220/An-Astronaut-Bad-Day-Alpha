using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAsteroidBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float AsteroidVelocity;
    public GameObject ToFixPrefab;
    public Transform Target;
    public GameObject ExplosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(transform.position.x > 30 || transform.position.x < -30 || transform.position.y > 30 || transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = Target.position - transform.position;
        rb.velocity = direction * AsteroidVelocity;
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
