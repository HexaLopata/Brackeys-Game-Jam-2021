using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourcePrefab;
    private List<AudioSource> _audioSources = new List<AudioSource>();
    public int PlayingSoundsCount => _audioSources.Count;

    private void Update()
    {
        for(int i = 0; i < _audioSources.Count; i++)
        {
            if(!_audioSources[i].isPlaying)
            {
                Destroy(_audioSources[i].gameObject);
                _audioSources.Remove(_audioSources[i]);
            }
        }
    }

    public void Play(AudioClip clip)
    {
        var audioSource = Instantiate(_audioSourcePrefab);
        audioSource.PlayOneShot(clip);
        _audioSources.Add(audioSource);
    }
}
