using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pipe : MonoBehaviour
{
    public  float Speed;
    private Rigidbody2D toControl;
    private System.Random random;

    void Start ()
    {
        random = new System.Random();
        toControl = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        toControl.transform.position += Vector3.left * Speed * Time.deltaTime; 
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Limiter>() != null)
            this.transform.position = new Vector3(10f, random.Next(-1, 2), 0f); ;
        
    }
   
}
