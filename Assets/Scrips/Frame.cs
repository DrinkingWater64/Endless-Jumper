using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] PlatformSpawner _spawner;
    [SerializeField] int _platLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        _spawner.CreateSpawnPoint();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("DEAD!!!!!!!");
        if (collision.CompareTag("platform"))
        {
            _platLeft += 1;
            Debug.Log(_platLeft);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
