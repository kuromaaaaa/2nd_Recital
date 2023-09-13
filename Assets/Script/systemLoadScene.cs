using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class systemLoadScene : MonoBehaviour
{
    Playercontroller _pc;
    GameObject[] _tagCount;
    [SerializeField] float _goalTimer;
    public float GoalTimer { get { return _goalTimer; } }
    float _timer;
    //ÉQÅ[ÉÄÉNÉäÉAbool
    bool _gameClear = false;
    public bool GameClear { get { return _gameClear; } }
    Tweener _run;
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _pc = _player.GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_pc.PlayerLife ==0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    _tagCount = GameObject.FindGameObjectsWithTag("Enemy");
    _timer += Time.deltaTime;
        if(_timer > _goalTimer && _tagCount.Length == 0)
        {
            _gameClear = true;
            _run = _player.transform.DOMove(new Vector2(_player.transform.position.x + 13, _player.transform.position.y), 1.5f).SetEase(Ease.Linear);
            StartCoroutine(nextScene());
        }
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2);
        _run.Kill();
        SceneManager.LoadScene("gameClearScene");
    }

}
