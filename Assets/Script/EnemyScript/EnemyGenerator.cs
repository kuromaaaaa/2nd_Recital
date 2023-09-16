using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] List<Generator> _enemyArray = new List<Generator>();
    float _nowTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _nowTimer += Time.deltaTime;
        for(int i = 0; i < _enemyArray.Count ; i++)
        {
            if (_enemyArray[i].Timer < _nowTimer)
            {
                Instantiate(_enemyArray[i].Enemy).transform.position = _enemyArray[i].Seisei;
                _enemyArray.RemoveAt(i);
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
