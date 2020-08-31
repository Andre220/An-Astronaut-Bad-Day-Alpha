using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enter and nothing");

        if (collider != null)
        {
            Debug.Log("Enter and something");
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Stay and nothing");

        if (collider != null)
        {
            Debug.Log("Stay and something");
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Exit and nothing");

        if (collider != null)
        {
            Debug.Log("Exit and something");
        }
    }
}
