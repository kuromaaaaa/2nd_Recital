using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OneButtonLoadScene : MonoBehaviour
{
    float _controlTimer;
    // Update is called once per frame
    void Update()
    {
        notcontrol();
        if (Input.GetButtonDown("Submit"))
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
