using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneScropt : MonoBehaviour
{
    GameObject _runner;
    bool _move = false;
    [SerializeField] string _LoadSceneString;
    // Start is called before the first frame update
    void Start()
    {
        _runner = GameObject.Find("Run1");
    }

    // Update is called once per frame
    void Update()
    {
        if(_move)
        {
            _runner.transform.position = new Vector2(_runner.transform.position.x + Time.deltaTime,_runner.transform.position.y);
        }
    }

    public void LoadScene(string name)
    {
        _move = true;
        StartCoroutine(nextScene(name));
    }
    IEnumerator nextScene(string N)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(N);
    }
}
