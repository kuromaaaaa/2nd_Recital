using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sousaSceneController : MonoBehaviour
{
    bool _first = true;
    // Update is called once per frame
    void Update()
    {
        if(_first && (Input.GetButtonDown("Submit") ||  Input.GetButtonDown("Fire1")))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if(Input.GetButtonUp("Submit") || Input.GetButtonUp("Fire1"))
            _first = false;
        if(!_first && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1")))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
