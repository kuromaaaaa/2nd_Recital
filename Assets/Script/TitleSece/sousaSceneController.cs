using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sousaSceneController : MonoBehaviour
{
    bool _first = true;
    float _controlTimer;
    // Update is called once per frame
    void Update()
    {
        notcontrol();
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
    void notcontrol()
    {
        if (!Input.anyKey && !Input.GetButtonDown("Jump") && Input.GetAxisRaw("Horizontal") == 0
            && Input.GetAxisRaw("Ltrigger") == 0 && Input.GetAxisRaw("Rtrigger") == 0)
        {//操作が何も行われていないとき
            _controlTimer += Time.deltaTime;
        }
        else
        {
            _controlTimer = 0;
        }
        if (_controlTimer > 60)
        {
            Debug.Log("ロード");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
