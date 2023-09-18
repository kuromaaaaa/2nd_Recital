using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneButtonLoadScene : MonoBehaviour
{
    float _Timer;
    // Update is called once per frame
    void Update()
    {
        _Timer += Time.deltaTime;
        if (Input.GetButtonDown("Submit") || _Timer > 10)
        {
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("TitleScene");
        }
    }
}
