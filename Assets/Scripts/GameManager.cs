using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public float gameWidth = 35;

    [HideInInspector]
    public int score = 0;

    [HideInInspector]
    public bool isGameActive = true;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }   
}
