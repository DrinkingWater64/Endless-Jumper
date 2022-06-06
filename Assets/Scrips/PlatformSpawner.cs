using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] GameObject _spanPoint;
    [SerializeField] int _platCount;
    List<GameObject> _platList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateSpawnPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (_platList.Count< 6)
        {
            CreateSpawnPoint();
        }
    }


    Vector2 CreateSpawnPoint()
    {
        Vector2 newSpawnPoint = new Vector2();
        for (int i = 0; i < _platCount; i++)
        {
            newSpawnPoint.x = Random.Range(-7f, 7f);
            newSpawnPoint.y += 1.5f;
            _platList.Add(Instantiate(_platformPrefab, newSpawnPoint, Quaternion.identity));
        }
        return newSpawnPoint;
    }
}
