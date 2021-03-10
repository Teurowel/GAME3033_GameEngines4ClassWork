using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Systems.Health_System
{
    public interface IDamagable
    {
        void TakeDamage(float damage);
        void Destroy(); //will be call if gameobject doesn't have health
    }
}