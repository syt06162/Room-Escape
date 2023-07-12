using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("WALL") || coll.CompareTag("PLAYER"))
            Destroy(this.gameObject);
    }
}
