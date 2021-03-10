using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Systems.Health_System;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] TMP_Text HealthText;
    
    HealthComponent HealthComponent;

    private void Awake()
    {
        PlayerEvents.OnPlayerHealthSet += OnPlayerHealthSet;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnPlayerHealthSet(HealthComponent healthComponent)
    {
        HealthComponent = healthComponent;   
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthComponent)
        {
            HealthText.text = HealthComponent.Health.ToString();
        }
    }
}
