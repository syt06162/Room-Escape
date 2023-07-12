using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    public int score = 0;

    public Text scoretext;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 미니게임을 종료합니다.
    /// </summary>
    public void End()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("End");
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "SCORE : " + score.ToString("00000");
    }
}
