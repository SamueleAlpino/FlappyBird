using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

[RequireComponent(typeof(BgMovement))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    [SerializeField]
    private AudioClip coin;
    [SerializeField]
    private CharacterController bird;
    [SerializeField]
    private AudioSource backgroundSound;

    private BgMovement background;
    private AudioSource source;
    private GameObject[] Prefabs = new GameObject[3];
    private System.Random random;
    private Vector3 spawnPos;
    private Vector3 offset;

    void Awake()
    {
        random = new System.Random();
        source = gameObject.AddComponent<AudioSource>();
        source.clip = coin;
        source.loop = false;
        source.playOnAwake = false;
        offset = new Vector3(8.5f, 0, 0);

        //Pipe creation
        for (int i = 0; i < Prefabs.Length; i++)
        {
            GameObject toInstantiate = Instantiate(pipePrefab);
            spawnPos = new Vector3(10f, random.Next(-1, 2), 0f);

            if (i == 0)
                toInstantiate.GetComponent<Transform>().position = spawnPos;
            else if (i == 1)
                toInstantiate.GetComponent<Transform>().position = spawnPos + offset;
            else
                toInstantiate.GetComponent<Transform>().position = spawnPos + (offset * 2f);

            Prefabs[i] = toInstantiate;
        }
    }

    private void Start()
    {
        background = GetComponent<BgMovement>();
    }
    private void Update()
    {
        if (bird.IsGrounded)
        {
            background.Speed = 0f;
            backgroundSound.volume = 0.5f;
            for (int i = 0; i < Prefabs.Length; i++)
            {
                Prefabs[i].GetComponent<Pipe>().Speed = 0f;
            }

        }
    }
}
