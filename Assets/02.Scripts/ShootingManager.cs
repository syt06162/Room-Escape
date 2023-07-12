using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingManager : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject endCanvas;
    public GameObject respawn;
    public GameObject player;

    public enum State
    {
        start, playing, end
    }

    public State state;

    private void Awake()
    {
        GameObject.Find("PlayerShip").SetActive(false);
        startCanvas.SetActive(true);
        endCanvas.SetActive(false);
        respawn.SetActive(false);
        player.SetActive(false);
    }

    float currentTime = 0f;
    bool allowStartScene = false;

    void Start()
    {
        state = State.start;
    }

    void Update()
    {
        switch (state)
        {
            case State.start:
                StartState();
                break;
            case State.playing:
                PlayingState();
                break;
            case State.end:
                EndState();
                break;
        }
    }

    void StartState()
    {
        startCanvas.SetActive(true);
        endCanvas.SetActive(false);
        player.SetActive(false);
        respawn.SetActive(false);
        currentTime = 0f;
        allowStartScene = false;
        player.GetComponent<PlayerCtrl>().hp = 999;
    }

    void PlayingState()
    {
        startCanvas.SetActive(false);
        respawn.SetActive(true);
        player.SetActive(true);
        if(player.GetComponent<PlayerCtrl>().hp <= 0)
        {
            state = State.end;
        }
    }


    void EndState()
    {
        endCanvas.SetActive(true);
        respawn.SetActive(false);
        player.SetActive(false);

        currentTime += Time.deltaTime;
        if(currentTime < 2.0f)
        {
            allowStartScene = true;
        }

        if (Input.anyKeyDown && allowStartScene)
        {
            state = State.start;
        }

    }

    public void StartGame()
    {
        state = State.playing;
    }

    public void EndScene()
    {
        SceneManager.LoadScene(1);
    }

}
