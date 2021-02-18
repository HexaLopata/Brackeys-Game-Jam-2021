using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriangleManager : MonoBehaviour
{
    public static TriangleManager Instance => _instance;

    [SerializeField] private TriangleManager _prefab;
    [SerializeField] private Triangle _trianglePrefab;
    [SerializeField] private List<Triangle> _triangles = new List<Triangle>();
    [SerializeField] private float _distanceBetweenTriangles = 1f;
    [SerializeField] private SynergySetter _synergySetter;

    private static TriangleManager _instance;
    private List<Vector2> _trianglesCoordinates = new List<Vector2>()
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(-1, 0),
        new Vector2(1, 0),
        new Vector2(0, -1),
        new Vector2(-1, 1),
        new Vector2(1, 1),
        new Vector2(-1, -1),
        new Vector2(1, -1),
        new Vector2(0, 2),
        new Vector2(-2, 0),
        new Vector2(2, 0),
        new Vector2(0, -2),
        new Vector2(-2, 1),
        new Vector2(2, 1),
        new Vector2(-2, -1),
        new Vector2(2, -1),
        new Vector2(-1, 2),
        new Vector2(1, 2),
        new Vector2(-1, -2),
        new Vector2(1, -2),
        new Vector2(0, 3),
        new Vector2(-3, 0),
        new Vector2(3, 0),
        new Vector2(0, -3),
    };

    private void Start()
    {
        _instance = this;
        CalculateSynergies();
    }

    public void AddNewTriangle(Weapon _weapon)
    {
        if(_trianglesCoordinates.Count > _triangles.Count)
        {
            var triangle = Instantiate(_trianglePrefab);
            Vector3 distance =  (_trianglesCoordinates[_triangles.Count] * _distanceBetweenTriangles);
            triangle.transform.position = _triangles[0].transform.position + distance;
            triangle.Weapon = _weapon;
            _triangles.Add(triangle);
            CalculateSynergies();
        }
    }

    public void RemoveTriangle(Triangle triangle)
    {
        _triangles.Remove(triangle);
        SortTriangles();
        CalculateSynergies();
    }

    private void SortTriangles()
    {
        for(int i = 1; i < _triangles.Count; i++)
        {
            Vector3 distance =  (_trianglesCoordinates[i] * _distanceBetweenTriangles);
            _triangles[i].transform.position = _triangles[0].transform.position + distance;
        }
    }

    private void CalculateSynergies()
    {
        var weapons = _triangles.Select(t => t.Weapon).Distinct();
        string synergies = string.Empty;
        foreach(var weapon in weapons)
        {
            // weapons with the same types
            var count = _triangles.Count(t => t.Weapon.SynergyIndex == weapon.SynergyIndex);
            weapon.SynergyLevel = count - 1;
            synergies += $"{weapon.name}: {count - 1} ";
        }
        _synergySetter.ShowSynergies(synergies);
    }
}
