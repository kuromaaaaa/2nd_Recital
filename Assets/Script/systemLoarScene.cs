using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class systemLoarScene : MonoBehaviour
{
    Playercontroller _pc;
    GameObject[] _tagCount;
    [SerializeField] float _goalTimer;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GameObject.Find("Player").GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_pc.PlayerLife ==0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        check();
        _timer += Time.deltaTime;
        if(_timer > _goalTimer && _tagCount.Length == 0)
        {
            SceneManager.LoadScene("gameClearScene");
        }
    }

    void check()
    {
        _tagCount = GameObject.FindGameObjectsWithTag("Enemy");
    }
}
