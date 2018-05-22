using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    [Range(10, 20)]
    public float JumpForce;
    public bool IsGrounded;

    [SerializeField]
    private AudioSource deadSound;
    [SerializeField]
    private Text text;

    private int Score;
    private Animator animator;
    private Rigidbody2D toControl;
    
    void Awake()
    {
        IsGrounded = false;
        toControl = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        deadSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsGrounded)
        {
            //If you want multiply for Time.DeltaTime but i mean it' s not necessary for this method
            toControl.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
        }

        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Start");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Pipe>() != null || collision.gameObject.GetComponent<Field>() != null)
        {
            IsGrounded = true;
            deadSound.Play();
            animator.SetBool("IsGrounded", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!IsGrounded)
        {
            Score++;
            text.text = Score.ToString();
        }
    }

}
