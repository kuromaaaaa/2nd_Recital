using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LoadSceneScropt : MonoBehaviour
{
    GameObject _runner;
    Tweener _run;
    [SerializeField] string _LoadSceneString;
    // Start is called before the first frame update
    void Start()
    {
        _runner = GameObject.Find("Run1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        Tweener _run = _runner.transform.DOMove(new Vector2(_runner.transform.position.x + 13, _runner.transform.position.y),1.5f).SetEase(Ease.Linear);
        StartCoroutine(nextScene(name));
    }
    IEnumerator nextScene(string N)
    {
        _run.Kill();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(N);
    }
}
