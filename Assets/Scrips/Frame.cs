using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    [SerializeField] PlatformSpawner _spawner;
    [SerializeField] int _platLeft = 0;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        _spawner.SpawnInitialPlatform();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("platform"))
        {
            _platLeft += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        speed = speed + Time.deltaTime*.125f;
        _spawner.KeepSpawning();

    }
}
