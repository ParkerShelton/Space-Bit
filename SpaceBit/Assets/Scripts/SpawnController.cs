using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

  public GameObject planet;
  public Transform asteroid;

  private Vector3 planetSpawn = new Vector3(0f, 0f, 0f);

  void Start() {
    Instantiate (planet, planetSpawn, Quaternion.Euler(0, 0, 0));

    SpawnAstroid();
  }

  void Update() {

  }


  void SpawnAstroid() {

    /*---- Bottom of screen ----*/
    for(int i = 0; i < 5; i++) {
      float xRand = Random.Range (-0.25f, 1.25f);
      float yRand = Random.Range (0.0f, -1.0f);

      Vector3 asteroidPos = Camera.main.ViewportToWorldPoint (new Vector3 (xRand, yRand, 0f));

      Instantiate (asteroid, asteroidPos, Quaternion.identity);
    }

    /*---- Top of screen ----*/
    for(int i = 0; i < 5; i++) {
      float xRand = Random.Range (-0.25f, 1.25f);
      float yRand = Random.Range (1.0f, 2.0f);

      Vector3 asteroidPos = Camera.main.ViewportToWorldPoint (new Vector3 (xRand, yRand, 0f));

      Instantiate (asteroid, asteroidPos, Quaternion.identity);
    }
  }


}
