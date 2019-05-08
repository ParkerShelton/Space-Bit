using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

  public Transform planet;

  private float asteroidSpeed = 1.0f;

  void Start() {
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
  }

  void Update() {
    transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, (asteroidSpeed * Time.deltaTime));
  }
}
