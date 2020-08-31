using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;

    public AudioSource ConsertoAudio;
    //Player life is 100;
    public LifeComponent spaceshipLife;

    public Transform CenterPivotPoint;

    public GameObject PointText;

    public float rotationSpeed;
    
    public float aproximationSpeed;

    public Vector3 center;

    public float maxDistanceFromShip;

    public float Fixing;

    public LineRenderer cordaoUmbilicalEspacial;

    public float FixingVelocity;

    public Text Points;

    Rigidbody2D rb;

    void Start()
    {
        instance = this;
        ConsertoAudio = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.centerOfMass = center;
        cordaoUmbilicalEspacial = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        cordaoUmbilicalEspacial.SetPosition(0, gameObject.transform.position);
        cordaoUmbilicalEspacial.SetPosition(1, CenterPivotPoint.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotateRigidbody2D(CenterPivotPoint, rotationSpeed);
        MoveRigidbody2DTowardsTarget(CenterPivotPoint, aproximationSpeed);
    }

    void MoveRigidbody2DTowardsTarget(Transform pivotPoint, float aproximationVelocity)
    {
        Vector3 direction = pivotPoint.position - transform.position;

        rb.AddForce(direction.normalized * aproximationVelocity * Input.GetAxis("Vertical"), ForceMode2D.Force);
    }

    void RotateRigidbody2D(Transform pivotPoint,float rotationVelocity)
    {
        Vector3 dir = (CenterPivotPoint.position - gameObject.transform.position).normalized;

        Vector3 cross = Vector3.Cross(dir, Vector3.forward);

        rb.velocity = cross * rotationVelocity * Input.GetAxis("Horizontal");
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "SpaceshipFix")
        {
            print("Trigged");

            ConsertoAudio.Play();
            Fixing += Time.deltaTime * FixingVelocity;
            if (Fixing > 1)
            {
                Destroy(collider.gameObject);
                Fixing = 0;
                spaceshipLife.LifeValue += 10;
                //ShowPointsUI("+",100);

                Points.text = (int.Parse(Points.text.ToString()) + 100).ToString();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        print("Untrigged");
        if (collider.tag == "SpaceshipFix")
        {
            ConsertoAudio.Stop();
            Fixing = 0;
        }
    }

    void ShowPointsUI(string prefix, int PointsValue)
    {
        GameObject PointsText = PointText;
        PointsText.GetComponent<TextMeshPro>().text = prefix + " " + PointsValue.ToString();
        Instantiate(PointsText, gameObject.transform.position, Quaternion.identity);

        Points.text = (int.Parse(Points.text.ToString()) + PointsValue).ToString();
    }
}
