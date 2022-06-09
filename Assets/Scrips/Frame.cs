using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Frame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _score;
    public int score = 0;

    [SerializeField] PlatformSpawner _spawner;
    [SerializeField] int _platLeft = 0;
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.instance.GoMenu();
        }
        int scoreN = score / 250;
        GameState.instance._score = scoreN;
        _score.text = (scoreN).ToString();
        _spawner.KeepSpawning();

        score += 1;
    }
}
