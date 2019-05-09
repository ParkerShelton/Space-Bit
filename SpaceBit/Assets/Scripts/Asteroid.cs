using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

  public Transform planet;

  private SpriteRenderer spriteR;
  private float asteroidSpeed = 1.0f;

  void Start() {
    spriteR = gameObject.GetComponent<SpriteRenderer> ();
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

    RandomSize();
  }

  void Update() {
    transform.position = Vector3.MoveTowards(transform.position, planet.transform.position, (asteroidSpeed * Time.deltaTime));
  }

  void RandomSize() {
    float randSize = Random.Range(0.8f, 1.5f);
    var x = (transform.localScale.x) * randSize;
    var y = (transform.localScale.y) * randSize;

    transform.localScale = new Vector3(x, y, 1);

    SphereCollider collider = transform.GetComponent<SphereCollider>();

    collider.radius = transform.localScale.x * 2;

    // if(x > 0.3f) {
    //   collider.radius = 0.3f;
    // } else if (x < 0.2f) {
    //   collider.radius = 0.2f;
    // } else {
    //   collider.radius = x;
    // }
  }
}
