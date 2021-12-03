using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDTrigger : MonoBehaviour
{
    private BoxCollider2D endTriggerUI;    
    // Start is called before the first frame update
    void Start()
    {
        endTriggerUI = GetComponent<BoxCollider2D>();
    }

    void OnCollision2D(BoxCollider2D endTriggerUI)
    {
        Debug.Log("Entered");
    }
}
