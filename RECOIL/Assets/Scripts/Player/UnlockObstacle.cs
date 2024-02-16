using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockObstacle : MonoBehaviour
{
    public GameObject GameObject;
    public Collider2D collider;

    PlayerMovement _playerMovementScript;

    private void Awake()
    {
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }

}
