using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public int hp;
    public int initHp = 5;
    public int enemyPoint;

    public Transform tr;
    public GameObject effect;

    void Awake()
    {
        hp = initHp;
    }

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PLAYER" ))
            Destroy(this.gameObject);
        if (coll.CompareTag("PLAYER_B"))
            hp--;

        if (coll.CompareTag("WALL"))
            Destroy(this.gameObject);

        if (hp <= 0)
        {
            GameManager.Instance.score += enemyPoint;
            Instantiate(effect, tr.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
