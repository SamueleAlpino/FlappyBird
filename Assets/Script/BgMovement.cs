using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMovement : MonoBehaviour
{
    public List<Transform> toMove;
    public Transform Limit;
    public Transform TargetSpawn;
    public float Speed;
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < toMove.Count; i++)
        {
            toMove[i].position -= Vector3.left  * Time.deltaTime * Speed;
            if (toMove[i].position.x < Limit.position.x)
                toMove[i].position = TargetSpawn.position;
        }
	}
}
