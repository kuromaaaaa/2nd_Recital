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
    //ゲームクリアbool
    bool _gameClear = false;
    public bool GameClear { get { return _gameClear; } }
    bool _move = false;
    GameObject _player;
    [SerializeField] GameObject _runPrefub;
    GameObject _clearRunner;

    float _controlTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _pc = _player.GetComponent<Playercontroller>();
    }

    // Update is called once per frame
    void Update()
    {
        //一定時間操作が行われない場合タイトルに戻る
        notcontrol();
        if(_pc.PlayerLife ==0)
        {
            Destroy(_player);
            Destroy(GameObject.Find("MousePosition"));
            StartCoroutine(GameOverScene());
        }
    _tagCount = GameObject.FindGameObjectsWithTag("Enemy");
    _timer += Time.deltaTime;
        if(_timer > _goalTimer && _tagCount.Length == 0 && FindObjectOfType<EnemyGenerator>().EnemyList.Count == 0)
        {
            _gameClear = true;
        }
        if (_player)
        {
            if (_gameClear == true && _player.GetComponent<Playercontroller>().JumpReady == true && _move == false)
            {
                _gameClear = false;
                _move = true;
                _clearRunner = Instantiate(_runPrefub);
                _clearRunner.transform.position = _player.transform.position;
                Destroy(_player);
                Destroy(GameObject.Find("MousePosition"));
                StartCoroutine(nextScene());
            }
        }
        if(_move)
        {
            _clearRunner.transform.position = new Vector2(_clearRunner.transform.position.x + Time.deltaTime*10, _clearRunner.transform.position.y);

        }
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("gameClearScene");
    }
    IEnumerator GameOverScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameOverScene");
    }

    void notcontrol()
    {
        if(!Input.anyKey && !Input.GetButtonDown("Jump") && Input.GetAxisRaw("Horizontal") == 0
            && Input.GetAxisRaw("Ltrigger") == 0 && Input.GetAxisRaw("Rtrigger") == 0)
        {//操作が何も行われていないとき
            _controlTimer += Time.deltaTime;
        }
        else
        {
            _controlTimer = 0;
        }
        if(_controlTimer > 60)
        {
            Debug.Log("ロード");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
