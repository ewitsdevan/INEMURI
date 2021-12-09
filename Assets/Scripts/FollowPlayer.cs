using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothness;

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetPosition;

    void Update()
    {
        // Camera follows the player with specified offset position
        targetPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        // Smooths camera movement
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothness);
    }
}
