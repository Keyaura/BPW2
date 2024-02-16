using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyText : MonoBehaviour
{
    public TMP_Text keytext;
    public PlayerMovement _playerMovementScript;
    private void Awake()
    {
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }
    void Update()
    {
        keytext.SetText(_playerMovementScript.playerkeys.ToString());
    }
}
