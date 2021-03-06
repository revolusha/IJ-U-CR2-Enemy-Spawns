using System.Collections;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] private Rat _prefab;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform _spawns;
    [SerializeField] private float _timeInterval = 2f;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_spawns.childCount];

        for (int i = 0; i < _spawns.childCount; i++)
        {
            _spawnPoints[i] = _spawns.GetChild(i);
        }

        StartCoroutine(SpawnRatJob());
    }

    private IEnumerator SpawnRatJob()
    {
        const int Count = 2;

        yield return new WaitForSeconds(_timeInterval);

        for (int i = 0; i < Count; i++)
        {
            SpawnRat();
        }

        StartCoroutine(SpawnRatJob());
    }

    private void SpawnRat()
    {
        const float MinLifeTime = 10f;
        const float MaxLifeTime = 25f;

        int index = Random.Range(0, _spawns.childCount);

        var rat = Instantiate(_prefab, _spawns.GetChild(index).position, Quaternion.identity, transform);
        rat.GetComponent<CircleCollider2D>().isTrigger = true;
        rat.KillAfter(Random.Range(MinLifeTime, MaxLifeTime));
        rat.SetPath(_path);
    }
}
