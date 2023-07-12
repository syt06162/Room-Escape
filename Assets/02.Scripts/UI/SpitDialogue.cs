using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpitDialogue : MonoBehaviour
{
    public int objId;
    int sceneNo;

    void Start()
    {
        sceneNo = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spit();
        }
    }

    void Spit()
    {

    }
}
