using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndManager : MonoBehaviour
{
    public Text ScoreEndText;

    void Start()
    {
        // ScoreEndText = 
    }
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("Start");
        }
    }
}
