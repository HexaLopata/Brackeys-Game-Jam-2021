using System.Collections.Generic;
using UnityEngine;
public class Core
{
    public static Core Instance
    {
        get
        {
            if(_instance == null)
                _instance = new Core();
            return _instance;
        }
    }

    public List<Weapon> WeaponPull => _weapons;
    public AudioSystem AudioSystem 
    {
        get => _audioSystem;
        set => _audioSystem = value;
    }

    private static Core _instance;
    private List<Weapon> _weapons = new List<Weapon>();
    private AudioSystem _audioSystem;

    private Core() { }
}
