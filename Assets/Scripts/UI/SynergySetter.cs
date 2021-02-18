using UnityEngine;
using UnityEngine.UI;

public class SynergySetter : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void ShowSynergies(string synergies)
    {
        _text.text = $"Synergies: {synergies}";
    }
}
