using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class goalBarUI : MonoBehaviour
{
    GameObject _nowTimer;
    RectTransform _rTF;
    systemLoadScene _sls;
    [SerializeField] float _barStart;
    [SerializeField] float _barEnd;
    float _distance;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        _sls = GameObject.Find("--system--").GetComponent<systemLoadScene>();
        _distance = _barEnd - _barStart;
        _nowTimer = GameObject.Find("nowTimer");
        _rTF = _nowTimer.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_nowTimer.transform.localPosition.x < _barEnd)
        {
            _rTF.localPosition = new Vector3((_distance / _sls.GoalTimer) * _timer + _barStart, _nowTimer.transform.localPosition.y, 0);
        }
    }
}
