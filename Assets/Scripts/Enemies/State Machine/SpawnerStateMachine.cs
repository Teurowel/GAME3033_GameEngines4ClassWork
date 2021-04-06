using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies.Spawners
{
    public enum SpawnerStateEnum
    {
        Beginner,
        Intermediate,
        Hard,
        Complete
    }

    public class SpawnerStateMachine : StateMachine<SpawnerStateEnum>
    {


    }

    public class SpawnerState : State<SpawnerStateEnum>
    {
        protected ZombieSpawner Spanwer;

        public SpawnerState(ZombieSpawner spawner, SpawnerStateMachine stateMachine)
            : base(stateMachine)
        {
            Spanwer = spawner;
        }

        protected void SpawnZombie()
        {
            GameObject zombieToSpawn = Spanwer.ZombiePrefabs[Random.Range(0, Spanwer.ZombiePrefabs.Length)];
            SpawnerVolume spawnVolume = Spanwer.SpawnVolumes[Random.Range(0, Spanwer.SpawnVolumes.Length)];

            GameObject zombie = 
                Object.Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

            zombie.GetComponent<ZombieComponent>().Initialize(Spanwer.TargetObject);
        }
    }

    class ZombieWaveSpawnerState : SpawnerState
    {
        public int ZombieToSpawn = 5;
        public SpawnerStateEnum NextState = SpawnerStateEnum.Intermediate;

        private int TotalZombiesKilled = 0;

        public ZombieWaveSpawnerState(ZombieSpawner spawner, SpawnerStateMachine stateMachine)
            : base(spawner, stateMachine)
        {

        }

        public override void Start()
        {
            base.Start();

            for(int i = 0; i < ZombieToSpawn; ++i)
            {
                SpawnZombie();
            }
        }
    }
}
