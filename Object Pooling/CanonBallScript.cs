using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CanonBallScript : MonoBehaviour {
    void OnEnable() {
        transform.position = transform.parent.position;
        int duration = Random.Range(3, 7);
        int dir = transform.parent.position.x < 0 ? 1 : -1;
        if (dir == -1) transform.GetComponent<SpriteRenderer>().flipX = true;
        transform.DOMoveX(GamePlayParameters.screenBounds.x * dir, duration).SetEase(Ease.Linear).OnComplete(
            () => { transform.parent.GetComponent<CanonScript>().addToPool(this.gameObject); }
        );
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<PlayerTopScript>() != null && !PlayerParams.isOnShield && !PlayerParams.isOnJumpItemBoost) {
            //destroy player
            other.gameObject.transform.parent.DOPause();
            other.transform.parent.GetChild(0).gameObject.SetActive(false);
            other.transform.parent.GetChild(1).gameObject.SetActive(false);
            DOTween.Sequence()
            .Append(other.gameObject.transform.parent.DOLocalJump(other.gameObject.transform.parent.position + Vector3.up * 2f, 1f, 1, 1f))
            .Insert(0.25f, other.gameObject.transform.parent.DOLocalRotate(new Vector3(-180, 0, -30), 0.5f, RotateMode.FastBeyond360))
            .Append(other.gameObject.transform.parent.DOMove(new Vector3(0, -2 * GamePlayParameters.screenBounds.y, 0), 3f)).SetEase(Ease.Linear)
            .OnComplete(() => {
                GamePlayParameters.isGameover = true;
            });
        }
    }
}
