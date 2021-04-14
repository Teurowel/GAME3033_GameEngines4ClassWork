using System.Collections;
using System.Collections.Generic;
using Systems.Health_System;
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
        protected ZombieSpawner Spawner;

        public SpawnerState(ZombieSpawner spawner, SpawnerStateMachine stateMachine)
            : base(stateMachine)
        {
            Spawner = spawner;
        }

        protected void SpawnZombie()
        {
            GameObject zombieToSpawn = Spawner.ZombiePrefabs[Random.Range(0, Spawner.ZombiePrefabs.Length)];
            SpawnerVolume spawnVolume = Spawner.SpawnVolumes[Random.Range(0, Spawner.SpawnVolumes.Length)];

            GameObject zombie = 
                Object.Instantiate(zombieToSpawn, spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);

            zombie.GetComponent<ZombieComponent>().Initialize(Spawner.TargetObject);
            zombie.GetComponent<HealthComponent>().OnDeath += OnZombieDeath; // add to event
        }

        protected virtual void OnZombieDeath()
        {

        }
    }

    class ZombieWaveSpawnerState : SpawnerState
    {
        public int ZombiesToSpawn = 5;
        public SpawnerStateEnum NextState = SpawnerStateEnum.Intermediate;

        private int TotalZombiesKilled = 0;

        public ZombieWaveSpawnerState(ZombieSpawner spawner, SpawnerStateMachine stateMachine)
            : base(spawner, stateMachine)
        {

        }

        public override void Start()
        {
            base.Start();

            for(int i = 0; i < ZombiesToSpawn; ++i)
            {
                SpawnZombie();
            }
        }

        protected override void OnZombieDeath()
        {
            base.OnZombieDeath();
            Debug.Log("Zombie killed");

            TotalZombiesKilled++;
            if(TotalZombiesKilled < ZombiesToSpawn)
            {
                return;
            }

            StateMachine.ChangeState(NextState);
            Spawner.CompleteWave(NextState);
        }
    }
}
