using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private GameSound _gameSoundPrefab;

    private Dictionary<int, GameSound> _audioEffects = new Dictionary<int, GameSound>();

    private void Update()
    {
        RemoveUselessGameSounds();
    }

    private void RemoveUselessGameSounds()
    {
        List<int> toRemove = new List<int>();
        foreach(var gameSound in _audioEffects)
        {
            if(gameSound.Value.PlayingSoundsCount == 0)
            {
                toRemove.Add(gameSound.Key);
            }
        }

        foreach(int layer in toRemove)
        {
            Destroy(_audioEffects[layer].gameObject);
            _audioEffects.Remove(layer);
        }
    }

    public void TryPlaySound(AudioClip clip, int soundLayer, int maxPlayingSoundCount)
    {
        if(_audioEffects.ContainsKey(soundLayer))
        {
            if(_audioEffects[soundLayer].PlayingSoundsCount < maxPlayingSoundCount)
            {
                _audioEffects[soundLayer].Play(clip);
            }
        }
        else
        {
            var gameSound = Instantiate(_gameSoundPrefab);
            gameSound.Play(clip);
            _audioEffects.Add(soundLayer, gameSound);
        }
    }
}
