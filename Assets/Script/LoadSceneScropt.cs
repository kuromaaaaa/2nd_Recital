using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScropt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string name)
    {

        StartCoroutine(nextScene(name));

    }
    IEnumerator nextScene(string N)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(N);
    }
}
