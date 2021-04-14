using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health_System;
using UnityEngine.SceneManagement;

public class PlayerHealthComponent : HealthComponent
{
    // Start is called before the first frame update
    protected void Start()
    {
        PlayerEvents.Invoke_OnPlayerHealthSet(this);
    }

    public override void Destroy()
    {
        base.Destroy();

        SceneManager.LoadScene("MenuScene");
        
    }
}
