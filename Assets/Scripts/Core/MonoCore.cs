﻿using UnityEngine;
using System.Collections.Generic;

public class MonoCore : MonoBehaviour
{
    public Core _core;
    
    [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
    [SerializeField] private AudioSystem _audioSystem;

    private void Start()
    {
        InitWeaponPull();
    }

    private void InitWeaponPull()
    {
        _core = Core.Instance;
        foreach (var weapon in _weapons)
        {
            _core.WeaponPull.Add(weapon);
        }
        _core.AudioSystem = _audioSystem;
    }

}
