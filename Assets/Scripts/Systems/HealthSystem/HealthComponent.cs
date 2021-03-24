using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health_System;
using System;

namespace Systems.Health_System
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public float Health => CurrentHealth;
        public float MaxHealth => TotalHealth;

        float CurrentHealth;
        [SerializeField] float TotalHealth;

        // Start is called before the first frame update
        protected virtual void Awake()
        {
            CurrentHealth = TotalHealth;
        }
        

        public virtual void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            Debug.Log(damage);
            if(CurrentHealth <= 0)
            {
                Destroy();
            }
        }

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public void HealPlayer(int effect)
        {
            if(CurrentHealth < MaxHealth && CurrentHealth > 0)
            {
                CurrentHealth += effect;
            }

            if(CurrentHealth <= 0)
            {
                Destroy();
            }
        }
    }

}