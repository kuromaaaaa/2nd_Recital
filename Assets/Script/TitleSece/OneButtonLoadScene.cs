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
        {//���삪�����s���Ă��Ȃ��Ƃ�
            _controlTimer += Time.deltaTime;
        }
        else
        {
            _controlTimer = 0;
        }
        if (_controlTimer > 60)
        {
            Debug.Log("���[�h");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
