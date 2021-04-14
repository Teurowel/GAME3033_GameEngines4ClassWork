using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies.Spawners;

[RequireComponent(typeof(SpawnerStateMachine))]
public class ZombieSpawner : MonoBehaviour, ISavable
{
    public delegate void WaveComplete(SpawnerStateEnum CurrentState);
    public event WaveComplete OnWaveComplete;

    private bool Initialized = false;

    [SerializeField] int NumberOfZombiesToSpawn;

    public GameObject[] ZombiePrefabs; //array of zombie prefab

    public SpawnerVolume[] SpawnVolumes;

    public GameObject TargetObject => FollowGameObject;
    GameObject FollowGameObject;

    private SpawnerStateMachine StateMachine;

    private SpawnerStateEnum StartingState;

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
            ZombiesToSpawn = 5,
            NextState = SpawnerStateEnum.Intermediate
        };

        StateMachine.AddState(SpawnerStateEnum.Beginner, beginnerWave);

        ZombieWaveSpawnerState intermediateWave = new ZombieWaveSpawnerState(this, StateMachine)
        {
            ZombiesToSpawn = 10,
            NextState = SpawnerStateEnum.Complete
        };

        StateMachine.AddState(SpawnerStateEnum.Intermediate, intermediateWave);


        StateMachine.Initialize(StartingState);



        //for(int zombieCount = 0; zombieCount < NumberOfZombiesToSpawn; ++zombieCount)
        //{
        //    SpawnZombie();
        //}
    }

    public void CompleteWave(SpawnerStateEnum NextState)
    {
        OnWaveComplete?.Invoke(NextState);
    }

    public SaveDataBase SaveData()
    {
        SpawnerSaveData saveData = new SpawnerSaveData
        {
            Name = gameObject.name,
            CurrentState = StateMachine.ActiveEnumState
        };

        return saveData;

    }

    public void LoadData(SaveDataBase saveData)
    {
        SpawnerSaveData spawnerSaveData = (SpawnerSaveData)saveData;

        StartingState = spawnerSaveData.CurrentState;
        //StateMachine.Initialize(spawnerSaveData.CurrentState);
        //Initialized = true;
    }

    //void SpawnZombie()
    //{
    //    GameObject zombieToSpawn = ZombiePrefabs[Random.Range(0, ZombiePrefabs.Length)];
    //    SpawnerVolume spawnVolume = SpawnVolumes[Random.Range(0, SpawnVolumes.Length)];

    //    GameObject zombie = Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

    //    zombie.GetComponent<ZombieComponent>().Initialize(FollowGameObject);
    //}

    [System.Serializable]
    public class SpawnerSaveData : SaveDataBase
    {
        public SpawnerStateEnum CurrentState;
    }
}
