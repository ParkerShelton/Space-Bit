using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeAsteroid : MonoBehaviour {

  // public Transform planet;
  public GameObject planet;

  private SpriteRenderer spriteR;
  private Rigidbody rb;
  private float asteroidSpeed;
  private float asteroidTorque;

  void Start() {
    spriteR = gameObject.GetComponent<SpriteRenderer> ();
    rb = gameObject.GetComponent<Rigidbody>();
    transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

    asteroidSpeed = Random.Range(5.0f, 10.0f);
    asteroidTorque = Random.Range(0.0f, 5.0f);

    rb.AddForce((planet.transform.position - gameObject.transform.position) * asteroidSpeed);
    rb.AddTorque(new Vector3(0f, 0f, asteroidTorque));

    RandomSize();
  }


  void RandomSize() {
    float randSize = Random.Range(1.2f, 1.5f);
    var x = (transform.localScale.x) * randSize;
    var y = (transform.localScale.y) * randSize;

    transform.localScale = new Vector3(x, y, 1);

    SphereCollider collider = transform.GetComponent<SphereCollider>();

    collider.radius = transform.localScale.x * 5;
  }
}
