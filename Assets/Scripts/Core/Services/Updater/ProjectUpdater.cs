using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectUpdater : MonoBehaviour, IProjectUpdater
{
    public static ProjectUpdater Instance;
    public event Action UpdateCalled;
    public event Action FixedUpdateCalled;
    public event Action LateUpdateCalled;

    public bool IsPaused { get; private set; } = false;
    private void Awake()
    {
        if(Instance == null) 
        {
            Instance= this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (IsPaused) { return; }
        UpdateCalled?.Invoke();
    }

    private void FixedUpdate()
    {
        if (IsPaused) { return; }
        FixedUpdateCalled?.Invoke();
    }

    private void LateUpdate()
    {
        if (IsPaused) { return; }
        LateUpdateCalled?.Invoke();
    }
}
