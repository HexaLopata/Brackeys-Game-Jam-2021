using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveNumberSetter : MonoBehaviour
{
    [SerializeField] private WaveController _waveController;

    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetWaveNumber()
    {
        _text.text = "Wave: " + _waveController.WaveNumber;
    }
}
