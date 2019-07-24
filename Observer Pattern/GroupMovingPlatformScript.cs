using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupMovingPlatformScript : MonoBehaviour {
    private MovingPlatformGroupScript mpgs;
    void OnEnable() {
        mpgs = transform.parent.GetComponent<MovingPlatformGroupScript>();
        if (mpgs == null) {
            Debug.Log(SharedConstantsAndUtils.DEBUG_TAG + "ERROR : mpgs null");
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerTopScript>() == null &&
         other.gameObject.GetComponent<PlayerFeetScript>() != null
          && !PlayerParams.isOnJumpItemBoost) {
            mpgs.isCollisionDetected = true;
        }
    }
}
