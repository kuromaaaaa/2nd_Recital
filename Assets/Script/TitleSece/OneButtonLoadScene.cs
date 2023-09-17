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
            GetComponent<AudioSource>().Play();
            SceneManager.LoadScene("TitleScene");
        }
    }
    void notcontrol()
    {
        if (!Input.anyKey && !Input.GetButtonDown("Jump") && Input.GetAxisRaw("Horizontal") == 0
            && Input.GetAxisRaw("Ltrigger") == 0 && Input.GetAxisRaw("Rtrigger") == 0)
        {//ëÄçÏÇ™âΩÇ‡çsÇÌÇÍÇƒÇ¢Ç»Ç¢Ç∆Ç´
            _controlTimer += Time.deltaTime;
        }
        else
        {
            _controlTimer = 0;
        }
        if (_controlTimer > 60)
        {
            Debug.Log("ÉçÅ[Éh");
            SceneManager.LoadScene("TitleScene");
        }
    }
}
