using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

  public static GameController gameController;

  public int waveNumber;
  public int waveCountdown;
  public int shieldHealth;
  public bool planetDestroyed;

  private WaveController waveController;

  void Awake() {

    if(gameController == null) {
      DontDestroyOnLoad(gameObject);
      gameController = this;
    } else if(gameController != this) {
      Destroy(gameObject);
    }

    waveController = gameObject.GetComponent<WaveController>();

    shieldHealth = 100;
    planetDestroyed = false;
  }

  void Update() {
    waveNumber = waveController.waveNum;
    waveCountdown = Mathf.CeilToInt(waveController.waveCountdown);
  }


}
