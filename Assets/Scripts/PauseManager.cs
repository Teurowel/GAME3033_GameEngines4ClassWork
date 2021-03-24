//Find all IPausable object and stop them

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance = null;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UnPauseGame();
    }

    public void PauseGame()
    {
        //Can't find interface directly
        //We can use LINQ that is built in c# which iterate list effeiciently
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach(IPausable pauseObject in pausables)
        {
            pauseObject.PauseGame();
        }

        Time.timeScale = 0;

        //Enable cursor
        AppEvents.Invoke_OnMouseCursorEnable(true);

    }

    public void UnPauseGame()
    {
        //Can't find interface directly
        //We can use LINQ that is built in c# which iterate list effeiciently
        var pausables = FindObjectsOfType<MonoBehaviour>().OfType<IPausable>();
        foreach (IPausable pauseObject in pausables)
        {
            pauseObject.UnPauseGame();
        }

        Time.timeScale = 1;

        //Enable cursor
        AppEvents.Invoke_OnMouseCursorEnable(false);
    }


    private void OnDestroy()
    {
        UnPauseGame();
    }
}

//Any object that need to be paused will inherit this interface
interface IPausable
{
    void PauseGame();
    void UnPauseGame();
}
