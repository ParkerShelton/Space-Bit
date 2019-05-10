using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

  public enum SpawnState { Spawning, Waiting, Counting };

  public GameObject planet;
  public Transform asteroid;
  public Transform largeAsteroid;

  public int waveNum;
  public float waveCountdown;

  private Vector3 planetSpawn = new Vector3(0f, 0f, 0f);

  //Time between cheking if there are any asteroids alive
  private SpawnState state = SpawnState.Counting;

  private int asteroidCount = 5;

  private float timeBetweenWaves = 5f;
  private float searchCountdown = 1f;
  private float rate = 2f;


  void Start() {
    Instantiate (planet, planetSpawn, Quaternion.Euler(0, 0, 0));
    waveCountdown = timeBetweenWaves;
  }


  void Update() {

    if(state == SpawnState.Waiting) {
      if(AsteroidIsAlive() == false) {

        WaveCompleted();

      } else {
        return;
      }
    }

    if(waveCountdown <= 0) {
      if(state != SpawnState.Spawning) {
        StartCoroutine( SpawnWave() );
      }

    } else {
      waveCountdown -= Time.deltaTime;
    }

  }


  void WaveCompleted() {
    state = SpawnState.Counting;
    waveCountdown = timeBetweenWaves;
    waveNum++;

    asteroidCount += 2;
    rate -= 0.25f;
  }


  bool AsteroidIsAlive() {
    searchCountdown -= Time.deltaTime;

    if(searchCountdown <= 0) {
      searchCountdown = 1f;

      if(GameObject.FindGameObjectWithTag("SmallAsteroid") == null && GameObject.FindGameObjectWithTag("LargeAsteroid") == null) {
        return false;
      }
    }

    return true;
  }



  IEnumerator SpawnWave() {
    state = SpawnState.Spawning;

    Debug.Log("Spawning Wave: " + waveNum);

    for(int i = 0; i < asteroidCount; i++) {
      SpawnAstroid();
      yield return new WaitForSeconds(rate);
    }


    state = SpawnState.Waiting;
    yield break;
  }


  public void SpawnAstroid() {

    // 0 = bottom of screen, 1 = top of screen
    int randDir = Mathf.RoundToInt(Random.Range(0f, 1f));

    int largeChance = Mathf.RoundToInt(Random.Range(0f, 10f));

    if(randDir == 0) {
      float xRand = Random.Range (-0.25f, 1.25f);
      float yRand = Random.Range (0.0f, -1.0f);

      Vector3 asteroidPos = Camera.main.ViewportToWorldPoint (new Vector3 (xRand, yRand, 0f));

      if(largeChance == 1) {
        Instantiate (largeAsteroid, asteroidPos, Quaternion.identity);

      } else {
        Instantiate (asteroid, asteroidPos, Quaternion.identity);
      }

    } else if(randDir == 1) {

      float xRand = Random.Range (-0.25f, 1.25f);
      float yRand = Random.Range (1.0f, 2.0f);

      Vector3 asteroidPos = Camera.main.ViewportToWorldPoint (new Vector3 (xRand, yRand, 0f));

      if(largeChance == 1) {
        Instantiate (largeAsteroid, asteroidPos, Quaternion.identity);

      } else {
        Instantiate (asteroid, asteroidPos, Quaternion.identity);
      }
    }
  }
}
