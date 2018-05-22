using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float counter;

    void Update ()
    {
        counter += 0.05f;

        this.gameObject.transform.position += new Vector3(0f,Mathf.Sin(counter) / 10f,0f);
	}
}
