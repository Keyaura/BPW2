using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AmmoText : MonoBehaviour
{
    
    public ShotgunLaunch _playerShotgunScript;
    public TMP_Text ammotext;

    private void Awake()
    {
        _playerShotgunScript = UnityEngine.Object.FindFirstObjectByType<ShotgunLaunch>();
    }
    // Update is called once per frame
    void Update()
    {
        ammotext.SetText(_playerShotgunScript.playerammo.ToString());
    }
}
