using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int ZombiesKilled;

    public void AddKill()
    {
        ZombiesKilled += 1;
        Debug.Log($"Zombies aniquilados: {ZombiesKilled}");
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
