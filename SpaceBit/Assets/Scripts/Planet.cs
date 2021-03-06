﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

  private int health = 5;
  private int smallAsteroidDamage = 1;


  void Update() {
    if(health <= 0) {
      health = 0;

      Debug.Log("Planet Destroyed");
    }
  }


	void OnCollisionEnter (Collision collision) {

    if(collision.gameObject.tag == "SmallAsteroid") {
      health = health - smallAsteroidDamage;

      Destroy(collision.gameObject);
    }

  }

}
