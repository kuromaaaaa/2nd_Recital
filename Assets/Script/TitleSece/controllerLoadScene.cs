using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerLoadScene : MonoBehaviour
{
    bool _first = false;
    RectTransform _rt;
    StartLoadScene _sls;
    AudioSource _as;
    bool _sousa = true;
    // Start is called before the first frame update
    void Start()
    {
        _rt = GetComponent<RectTransform>();
        _sls = GameObject.Find("StartButton").GetComponent<StartLoadScene>();
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_sousa)
        {
            return;
        }
        if ((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("crossY") > 0) && _first == false)
        {
            _as.Play();
            _first = true;
        }
        if ((Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("crossY") < 0) && _first == true)
        {
            _as.Play();
            _first = false;
        }

        //ポインター位置を変更
        if(_first)
        {
            _rt.localPosition = new Vector2(transform.localPosition.x,-130);
        }
        else
        {
            _rt.localPosition = new Vector2(transform.localPosition.x, -200);
        }
        //Aボタンでロード
        if(_first && Input.GetButtonDown("Submit"))
        {
            _sls.LoadScene("GameScene");
            _sousa = false;
        }
        if(_first == false && Input.GetButtonDown("Submit"))
        {
            FindObjectOfType<sousaButtonScript>().sousa();
        }


    }
}
