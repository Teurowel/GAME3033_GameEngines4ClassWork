using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.Spawners;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] int NumberOfZombiesToSpawn;

    [SerializeField] GameObject[] ZombiePrefabs; //array of zombie prefab

    [SerializeField] SpawnerVolume[] SpawnVolumes;

    GameObject FollowGameObject;

    // Start is called before the first frame update
    void Start()
    {
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");

        for(int zombieCount = 0; zombieCount < NumberOfZombiesToSpawn; ++zombieCount)
        {
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {
        GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
        SpawnerVolume spawnVolume = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

        GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

        zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
    }
}
