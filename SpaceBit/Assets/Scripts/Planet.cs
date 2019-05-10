using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

  // private int health = 5;
  private int smallAsteroidDamage = 1;
  private int largeAsteroidDamage = 5;


	void OnCollisionEnter (Collision collision) {

    if(collision.gameObject.tag == "SmallAsteroid") {

      if(GameController.gameController.shieldHealth > 0) {
        GameController.gameController.shieldHealth -= smallAsteroidDamage;

      } else {
        GameController.gameController.planetDestroyed = true;
      }

      Destroy(collision.gameObject);
    }

    if(collision.gameObject.tag == "LargeAsteroid") {

      if(GameController.gameController.shieldHealth > 0) {
        GameController.gameController.shieldHealth -= largeAsteroidDamage;

      } else {
        GameController.gameController.planetDestroyed = true;
      }

      Destroy(collision.gameObject);
    }

  }

}
