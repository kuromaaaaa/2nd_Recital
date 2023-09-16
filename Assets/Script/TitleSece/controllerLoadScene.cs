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
    // Start is called before the first frame update
    void Start()
    {
        _rt = GetComponent<RectTransform>();
        _sls = GameObject.Find("StartButton").GetComponent<StartLoadScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("crossY") > 0) && _first == false)
        {
            _first = true;
        }
        if ((Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("crossY") < 0) && _first == true)
        {
            _first = false;
        }

        //ポインター位置を変更
        if(_first)
        {
            _rt.localPosition = new Vector2(transform.localPosition.x,-250);
        }
        else
        {
            _rt.localPosition = new Vector2(transform.localPosition.x, -400);
        }
        //Aボタンでロード
        if(_first && Input.GetButtonDown("Submit"))
        {
            _sls.LoadScene("GameScene");
        }
        if(_first == false && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("sousaScene");
        }


    }
}
