using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public int hp;
    public int initHp = 10;

    public Rigidbody2D rb;
    public float speed = 400.0f;

    float h; //좌,우
    float v; //위,아래

    public Text HPtext;

    void Awake()
    {
        hp = initHp;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed * Time.deltaTime;

        //밖으로 못나가게 하기
        float size = Camera.main.orthographicSize;
        float offset = 0.6f;
        if (transform.position.y >= size - offset) 
        {
            transform.position = new Vector3(transform.position.x, size - offset, 0);
        }
        if (transform.position.y <= -size + offset)
        {
            transform.position = new Vector3(transform.position.x, -size + offset, 0);
        }

        float screenRation = (float) Screen.width / (float) Screen.height;
        float wSize = Camera.main.orthographicSize * screenRation;

        if (transform.position.x >= wSize - offset)
        {
            transform.position = new Vector3(wSize - offset, transform.position.y, 0);
        }
        if (transform.position.x <= -wSize + offset)
        {
            transform.position = new Vector3(-wSize + offset, transform.position.y, 0);
        }


        HPtext.text = "HP : " + hp.ToString("000"); //
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Meteor_1"))
            hp = hp - 55;

        if (coll.CompareTag("ENEMY_1"))
            hp = hp - 20;
        if (coll.CompareTag("ENEMY_1_B"))
            hp = hp - 10;

        if (coll.CompareTag("ENEMY_2"))
            hp = hp - 25;
        if (coll.CompareTag("ENEMY_2_B"))
            hp = hp - 14;

        if (coll.CompareTag("ENEMY_3"))
            hp = hp - 35;
        if (coll.CompareTag("ENEMY_3_B"))
            hp = hp - 19;

        if (coll.CompareTag("ENEMY_4"))
            hp = hp - 9999;

        if (coll.CompareTag("Enemy_7"))
            hp = hp - 40;


        if (hp <= 0)
        {
            GameManager.Instance.End();
        }
        
    }
}
