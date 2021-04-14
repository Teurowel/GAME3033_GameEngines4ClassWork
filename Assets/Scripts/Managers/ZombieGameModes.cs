using Enemies.Spawners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieGameModes : MonoBehaviour
{
    private ZombieSpawner Spawner;
    private void Awake()
    {
        Spawner = FindObjectOfType<ZombieSpawner>();
        Spawner.OnWaveComplete += OnWaveComplete;
    }

    private void OnWaveComplete(SpawnerStateEnum stateEnum)
    {
        if (stateEnum == SpawnerStateEnum.Complete)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene("MenuScene");
        }
    }
}
