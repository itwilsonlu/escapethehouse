using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlateController : MonoBehaviour
{
    bool hasHit = false;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("YellowBall")) {
            if (hasHit == false) {
                hasHit = true;
                GameData.balls++;
                Debug.Log("Hit");
            }
        }
    }
}
