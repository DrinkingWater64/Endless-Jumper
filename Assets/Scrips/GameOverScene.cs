using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScene : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _score;

    // Start is called before the first frame update
    void Start()
    {
        _score.text = GameState.instance._score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState.instance.GoMenu();
        }
    }
}
