using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameGlobeData : MonoBehaviour
{
    public event EventHandler OnSceneStart;
    public event EventHandler OnSceneEnd;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().isLoaded) OnSceneStart?.Invoke(this, EventArgs.Empty);
    }
}
