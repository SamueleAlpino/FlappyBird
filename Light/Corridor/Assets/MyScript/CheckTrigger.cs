using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool Hit ;

    private void OnTriggerEnter(Collider other)
    {
        Hit = false;
        if (other.gameObject.GetComponent<Trigger>() != null)
        {
          //  Destroy(other,1f);
            Hit = true;
            Debug.Log("Hit");
        }
    }
}
