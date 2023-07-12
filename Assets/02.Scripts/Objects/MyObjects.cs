using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyObjects : MonoBehaviour
{
    public static MyObjects Instance;
    public float ZoomRatio = 0.3f;
    public static int flag;

    public Transform target;
    public Transform room;
    protected Testmoving thePlayer;
    protected Camera theCamera;

    public enum Check
    {
        Door = 1,
        Rabbit = 1 << 1,
        Table = 1 << 2,
        Badge = 1 << 3,
        Moon = 1 << 4,
        GameConsole = 1 << 5,
        All = Door + Rabbit + Table + Badge + Moon + GameConsole

    };


    public virtual void Execute()
    {

    }

    private void Update()
    {
        //Debug.Log("현재" + flag);
    }

    private void Start()
    {

    }

}
