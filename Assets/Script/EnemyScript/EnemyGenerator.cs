using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] List<Generator> _enemyList = new List<Generator>();
    float _nowTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _nowTimer += Time.deltaTime;
        for(int i = 0; i < _enemyList.Count ; i++)
        {
            if (_enemyList[i].Timer < _nowTimer)
            {
                Instantiate(_enemyList[i].Enemy).transform.position = _enemyList[i].Seisei;
                _enemyList.RemoveAt(i);
            }
        }
    }
    [Serializable]
    public struct Generator
    {
        public float Timer;
        public GameObject Enemy;
        public Vector2 Seisei;
    }
}
