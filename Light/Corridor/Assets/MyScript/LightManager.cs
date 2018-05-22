using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Timer
{
    private float timeLimit;
    public bool IsActive { get; private set; }
    public float currentTime;

    public Timer(float timeLimit)
    {
        this.timeLimit = timeLimit;
    }

    public void Update()
    {
        if (IsActive)
        {
            currentTime += Time.deltaTime;
            if (currentTime > timeLimit)
                Stop();
        }
    }

    public void Start()
    {
        IsActive = true;
        currentTime = 0f;
    }

    public bool IsOver()
    {
        return currentTime > timeLimit;
    }

    public void Stop()
    {
        IsActive = false;
    }

    internal void Reset()
    {
        currentTime = 0f;
    }
}

public class LightManager : MonoBehaviour
{
    public GameObject TurnOff;
    public Material change;
    public CheckTrigger check;
    public Camera camera;
    public AudioSource BreakDown;
    public AudioSource Warning;
    public AudioSource Monster;
    public AudioSource FearSound;
    public AudioSource Explosion;
    public AudioSource CreepySound;
    //    public AudioSource Warning;

    private FirstPersonController fps;
    private ChangeLight[] lightsEmissive;
    private PointLight[] pointLight;
    private int index;
    private bool lerp;
    private bool fogLerp;
    private Timer timer;
    // Use this for initialization
    void Start()
    {
        lightsEmissive = FindObjectsOfType<ChangeLight>();
        pointLight = FindObjectsOfType<PointLight>();
        index = 0;
        fps = FindObjectOfType<FirstPersonController>();
        timer = new Timer(2f);
    }

    private void Update()
    {
        timer.Update();

        if (check.Hit)
        {
            if (index == 0)
            {
                lerp = true;
                Explosion.Play();
                BreakDown.Play();

                for (int i = 0; i < lightsEmissive.Length; i++)
                {
                    lightsEmissive[i].GetComponent<MeshRenderer>().material = change;
                }

                for (int i = 0; i < pointLight.Length; i++)
                {
                    pointLight[i].GetComponent<Light>().color = Color.red;
                }
                timer.Start();
            }
            else if (index == 1)
            {
                fps.m_WalkSpeed = 1.5f;
                Monster.Play();
                FearSound.Play();
            }
            else if (index == 2)
            {
                camera.gameObject.GetComponent<VolumetricFog>().enabled = true;
                CreepySound.Play();
                fogLerp = true;
            }

            index++;

            check.Hit = false;
        }

        if (timer.IsOver() && !timer.IsActive)
        {
            Warning.Play();
            timer.Reset();
        }
        

        if (lerp && TurnOff.GetComponent<Light>() != null)
            TurnOff.GetComponent<Light>().intensity = Lerp(TurnOff.GetComponent<Light>().intensity, 0f, 0.1f);

        if (fogLerp)
            camera.gameObject.GetComponent<VolumetricFog>().m_NearClip = Lerp(camera.gameObject.GetComponent<VolumetricFog>().m_NearClip, 0.1f, 0.01f);

    }

    private float Lerp(float start, float end, float t)
    {
        return (1 - t) * start + t * end;
    }
}
