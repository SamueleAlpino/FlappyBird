using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;

    public Transform RightOpen;
    public Transform LeftOpen;
    public bool Activate;

    private Vector3 closedPos;

    private void Start()
    {
        closedPos = transform.position;
    }
    void Update ()
    {
        if (Activate)
        {
            Left.transform.position  = Vector3.Lerp(Left.transform.position, LeftOpen.position, 0.05f);
            Right.transform.position = Vector3.Lerp(Right.transform.position, RightOpen.position, 0.05f);
        }
        else
        {
            Left.transform.position = Vector3.Lerp(Left.transform.position,closedPos, 0.05f);
            Right.transform.position = Vector3.Lerp(Right.transform.position, closedPos, 0.05f);
        }

    }
}
