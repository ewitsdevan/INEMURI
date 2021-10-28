using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticVariables
{
    private static float progress;
    private static int enemiesKilled;

    public static float Progress
    {
        get
        {
            return progress;
        }
        set
        {
            progress = value;
        }
    }

    public static int EnemiesKilled
    {
        get
        {
            return enemiesKilled;
        }
        set
        {
            enemiesKilled = value;
        }
    }
}
