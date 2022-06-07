using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] int _platCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public Vector2 CreateSpawnPoint()
    {
        int _counter = 0;
        int prevNumber = 1;
        Vector2 newSpawnPoint = new Vector2();
        newSpawnPoint.y = _spawnPoints[1].transform.position.y;
        for (int i = 0; i < _platCount; i++)
        {
            int x = Random.Range(0, 50)%3;
            if (x == prevNumber && _counter < 2)
            {
                _counter += 1;
                newSpawnPoint.x = _spawnPoints[x].transform.position.x - Random.Range(-3f,3f);
            }
            else if ((x - prevNumber) == 1 || (x-prevNumber) == -1)
            {
                _counter = 0;
                prevNumber = x;
                newSpawnPoint.x = _spawnPoints[x].transform.position.x;
            }
            else
            {
                Debug.Log("hit");
                continue;
            }
            newSpawnPoint.y += 2.5f;
            Instantiate(_platformPrefab, newSpawnPoint, Quaternion.identity);
        }
        return newSpawnPoint;
    }

    
}

