using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameManager
{
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        // @todo show start menu
    }

    public static void Reset()
    {
        SpawnerManager[] spawnerManagers = Object.FindObjectsOfType<SpawnerManager>();

        foreach (SpawnerManager spawnerManager in spawnerManagers)
        {
            spawnerManager.Reset();
        }
    }

    public static void GameOver()
    {
        // @todo show game over menu
    }
}
