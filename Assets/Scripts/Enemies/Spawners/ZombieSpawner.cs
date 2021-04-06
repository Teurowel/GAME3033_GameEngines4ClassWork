using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.Spawners;

[RequireComponent(typeof(SpawnerStateMachine))]
public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] int NumberOfZombiesToSpawn;

    public GameObject[] ZombiePrefabs; //array of zombie prefab

    public SpawnerVolume[] SpawnVolumes;

    public GameObject TargetObject => FollowGameObject;
    GameObject FollowGameObject;

    private SpawnerStateMachine StateMachine;

    private void Awake()
    {
        StateMachine = GetComponent<SpawnerStateMachine>();
        FollowGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        ZombieWaveSpawnerState beginnerWave = new ZombieWaveSpawnerState(this, StateMachine)
        {
            ZombieToSpawn = 5,
            NextState = SpawnerStateEnum.Complete
        };

        StateMachine.AddState(SpawnerStateEnum.Beginner, beginnerWave);
        StateMachine.Initialize(SpawnerStateEnum.Beginner);


        //for(int zombieCount = 0; zombieCount < NumberOfZombiesToSpawn; ++zombieCount)
        //{
        //    SpawnZombie();
        //}
    }

    //void SpawnZombie()
    //{
    //    GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
    //    SpawnerVolume spawnVolume = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

    //    GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

    //    zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
    //}
}
