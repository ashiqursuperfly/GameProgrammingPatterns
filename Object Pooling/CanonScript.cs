using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CanonScript : MonoBehaviour {

#pragma warning disable
    [SerializeField] private GameObject canonBall;
#pragma warning enable
    private int maxCannonBalls = 2, poolSize;
    private float interval = 3f;
    Queue<GameObject> pool;
    void OnEnable() {
        pool = new Queue<GameObject>();
        growPool();
    }
    private float t = 0;
    void Update() {
        t += Time.deltaTime;
        poolSize = pool.Count;
        if (t >= interval) {
            t = 0;
            if (pool.Count != 0) {
                GameObject g = pool.Dequeue();
                g.SetActive(true);
                g.GetComponent<CanonBallScript>().enabled = true;
            } else growPool();
        }
    }
    public void addToPool(GameObject g) {
        g.GetComponent<CanonBallScript>().enabled = false;
        g.SetActive(false);
        pool.Enqueue(g);
    }
    void growPool() {
        for (int i = 0; i < maxCannonBalls; i++) {
            GameObject g = Instantiate(canonBall, this.transform.position + (Vector3.right * 0.25f), this.transform.rotation);
            g.transform.SetParent(this.transform);
            pool.Enqueue(g);
        }
    }

}
