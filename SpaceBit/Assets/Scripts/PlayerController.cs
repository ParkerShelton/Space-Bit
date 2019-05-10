using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public Transform asteroid;
  private bool canClick = true;

  // Update is called once per frame
  void Update() {

    if(Input.GetMouseButton(0)) {
      RaycastHit hit;
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hit)) {

        if(canClick == true) {

          if (hit.transform.tag == "SmallAsteroid" ) {
            StartCoroutine(ClickCoolDown());
            Destroy(hit.transform.gameObject);
          }
          if (hit.transform.tag == "LargeAsteroid" ) {
            StartCoroutine(ClickCoolDown());
            ExplodeLargeAsteroid(new Vector3(hit.transform.position.x, hit.transform.position.y, 0f));
            Destroy(hit.transform.gameObject);
          }
        }
      }
    }
  }

  void ExplodeLargeAsteroid(Vector3 position) {

    for(int i = 0; i < 2; i++) {
      Instantiate (asteroid, position, Quaternion.Euler(0, 0, 0));
    }
  }

  IEnumerator ClickCoolDown() {
    canClick = false;

    yield return new WaitForSeconds(0.25f);

    canClick = true;
  }

}
