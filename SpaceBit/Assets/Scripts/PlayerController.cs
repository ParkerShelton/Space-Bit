using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Update is called once per frame
    void Update() {

      if(Input.GetMouseButton(0)) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
          if (hit.transform.tag == "SmallAsteroid" ) {
            Destroy(hit.transform.gameObject);
          }
        }
      }

    }
}
