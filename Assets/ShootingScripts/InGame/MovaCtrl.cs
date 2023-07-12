using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovaCtrl : MonoBehaviour
{
    public Transform tr;
    public float speed = 10f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
