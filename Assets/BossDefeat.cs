using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeat : StateMachineBehaviour
{
    public GameObject bossObject;

    public void BossDeath()
    {
        Destroy(bossObject);
    }
}
