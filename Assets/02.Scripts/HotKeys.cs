using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HotKeys : MonoBehaviour
{
    public bool shiftDown = false;
    public bool yDown = false;
    public bool oneDown = false;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            shiftDown = true;
        else
            shiftDown = false;

        if (Input.GetKey(KeyCode.Y))
            yDown = true;
        else
            yDown = false;


        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Y))
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(2);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(3);
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(4);
            }
            else if (Input.GetKey(KeyCode.Alpha5))
            {
                SceneManager.LoadScene(5);
            }
            else if (Input.GetKey(KeyCode.Alpha6))
            {
                SceneManager.LoadScene(6);
            }
        }
    }
}
