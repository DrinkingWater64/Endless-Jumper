using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] GameObject[] _spawnPoints;
    [SerializeField] int _platCount;
    GameObject currentPlat;
    int _counter = 0;
    int _prevNumber = 1;
    int[] _alterNumber = { 1, 5, 1 };

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log((1 + 1) % 2);
        _counter = 0;
        _prevNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    int ZeroOrTwo()
    {
        int num = Random.Range(10, 100);
        if (num%2 == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }




    Vector2 CreateSpawnPosition()
    {
        Vector2 newPosition = new Vector2();
        newPosition.y = 16f;
        int x = Random.Range(0, 50) % 3;
        if (_prevNumber == x && _counter <=1)
        {
            _counter += 1;
            newPosition = _spawnPoints[x].transform.position;
        }
        else if (_counter>=2)
        {
            Debug.Log("_counter >= 2");
            int newX = _alterNumber[x];
            if (x==5)
            {
                newX = ZeroOrTwo();
            }
            _prevNumber = newX;
            _counter = 0;
            newPosition = _spawnPoints[newX].transform.position;
        }
        else if (_prevNumber != x)
        {
            if (_prevNumber - x == 1 || x - _prevNumber == 1)
            {
                Debug.Log(x + " prev - x");
            _prevNumber = x;
            _counter = 0;
            newPosition = _spawnPoints[x].transform.position;
            }
            else
            {
                Debug.Log("else x - prev");
                _prevNumber = 1;
                _counter = 0;
                newPosition = _spawnPoints[1].transform.position;

            }
        }
        Debug.Log("prevous: " + _prevNumber);
        Debug.Log("counter: " + _counter);
        return newPosition;
    }

    void SpawnPlatform(Vector2 positon)
    {
        currentPlat = Instantiate(_platformPrefab, positon, Quaternion.identity);
    }


    public void SpawnInitialPlatform()
    {
        currentPlat = Instantiate(_platformPrefab, _spawnPoints[1].transform.position , Quaternion.identity);
    }


    public void KeepSpawning()
    {
        if ((_spawnPoints[1].transform.position.y - currentPlat.transform.position.y)  >= 2.5f)
        {
            Vector2 newPos = CreateSpawnPosition();
            SpawnPlatform( newPos);
        }
    }
}

