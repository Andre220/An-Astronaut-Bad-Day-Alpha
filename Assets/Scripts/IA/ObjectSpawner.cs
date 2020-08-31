using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public Transform EnviromentParent;

    public GameObject AsteroidPrefab;
    public GameObject DirectionalAsteroidPrefab;

    public Text Points;

    public float DirectionalAsteroidSpawnRate;
    public float HorizontalAsteroidSpawnRate;
    public float VerticalAsteroidSpawnRate;

    public Transform[] DirectionalAsteroidSpawnPositions;
    public int[] VerticalAsteroidPositions;
    public int[] HorizontalAsteroidPositions;

    public float AsteroidVelocity;
    public float SlowAsteroidVelocity = 0.5f;
    public float DirectionalVelocity;

    public int TimeToHarder;
    
    public int TimePoints;

    public float Timer;

    void Start()
    {
        StartCoroutine("SpawnDirectionalAsteroid");
        StartCoroutine("SpawnVerticallAsteroid");
        StartCoroutine("SpawnHorizontalAsteroid");
    }

    void Update()
    {
        Timer += Time.deltaTime;
        DefineDifficult();
    }

    void DefineDifficult()
    {
        if (Mathf.RoundToInt(Timer) > TimeToHarder)
        {
            TimeToHarder += TimeToHarder;

            AsteroidVelocity += 0.5f;
            DirectionalVelocity += 0.5f;

            DirectionalAsteroidSpawnRate -= 0.35f;
            HorizontalAsteroidSpawnRate -= 0.5f;
            VerticalAsteroidSpawnRate -= 0.5f;
        }

        if (Mathf.RoundToInt(Timer) > TimePoints)
        {

            TimePoints += 1;
            Points.text = (int.Parse(Points.text.ToString()) + 10).ToString();
        }


        //print($"Time to make game harder: {TimeToHarder}");
        //print($"Current Asteroid Velocity : {AsteroidVelocity}");
        //print($"Current D. Velocity : {DirectionalVelocity}");
        //print($"Current D. Asteroid Velocity : {(Timer / 10)}");

        //print($"Current D. Asteroid Spawn Rate: {(Timer / 5)}");
        //print($"Current Asteroid Spawn Rate : {(Timer / 7)}")
    }

    IEnumerator SpawnVerticallAsteroid()
    {
        yield return new WaitForSeconds(VerticalAsteroidSpawnRate);

        GameObject asteroid = AsteroidPrefab;

        asteroid.GetComponent<AsteroidBehaviour>().AsteroidVelocity = AsteroidVelocity;

        asteroid.SetActive(true);

        Vector3 spawnPosition = new Vector3(Random.Range(-15, 15), VerticalAsteroidPositions[Random.Range(0, 1)], 0);

        if (spawnPosition.y > 0)
        {
            asteroid.GetComponent<AsteroidBehaviour>().AsteroidVelocity *= -1;
        }

        Instantiate(asteroid, spawnPosition, Quaternion.identity, EnviromentParent);

        StartCoroutine("SpawnVerticallAsteroid");
    }

    IEnumerator SpawnHorizontalAsteroid()
    {
        yield return new WaitForSeconds(HorizontalAsteroidSpawnRate);

        GameObject asteroid = AsteroidPrefab;

        asteroid.GetComponent<AsteroidBehaviour>().AsteroidVelocity = AsteroidVelocity;

        asteroid.SetActive(true);

        Vector3 spawnPosition = new Vector3(HorizontalAsteroidPositions[Random.Range(0, 1)], Random.Range(-15, 15), 0);

        if (spawnPosition.x > 0)
        {
            asteroid.GetComponent<AsteroidBehaviour>().AsteroidVelocity *= -1;
        }

        Instantiate(asteroid, spawnPosition, Quaternion.identity, EnviromentParent);

        StartCoroutine("SpawnHorizontalAsteroid");
    }

    IEnumerator SpawnDirectionalAsteroid()
    {
        yield return new WaitForSeconds(DirectionalAsteroidSpawnRate);

        GameObject asteroid = DirectionalAsteroidPrefab;

        asteroid.GetComponent<DirectionalAsteroidBehaviour>().AsteroidVelocity = AsteroidVelocity;

        asteroid.SetActive(true);

        Instantiate(asteroid, DirectionalAsteroidSpawnPositions[Random.Range(0, DirectionalAsteroidSpawnPositions.Length)].position, Quaternion.identity, EnviromentParent);

        StartCoroutine("SpawnDirectionalAsteroid"); 
    }
}
