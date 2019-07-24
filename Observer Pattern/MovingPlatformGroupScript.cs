using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatformGroupScript : MonoBehaviour {
    // [HideInInspector]
    [HideInInspector] public bool isCollisionDetected = false;
#pragma warning disable
    [SerializeField] private List<GameObject> groupMovePlatforms;
#pragma warning enable

    int dir = 0;
    void Update() {
        if (isCollisionDetected) {
            movePlatforms();
            isCollisionDetected = false;
        }
    }
    public void movePlatforms() {
        foreach (GameObject g in groupMovePlatforms) {
            if (g != null && g.GetComponent<GroupMovingPlatformScript>() != null) {
                dir = Random.Range(0, 2);
                if (dir == 0) g.transform.DOLocalMoveX(g.transform.position.x + 0.12f, 0.5f);
                else g.transform.DOLocalMoveX(g.transform.position.x - 0.12f, 0.5f);
            }
        }

    }
}
