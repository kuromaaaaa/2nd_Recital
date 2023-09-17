using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    bool _first = true;
    RectTransform _rt;
    AudioSource _as;
    AudioSource _parentAs;
    float _controlTimer;
    // Start is called before the first frame update
    void Start()
    {
        _rt = GetComponent<RectTransform>();
        _as = GetComponent<AudioSource>();
        _parentAs = this.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        notcontrol();
        if ((Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("crossX") > 0) && _first == true)
        {
            _first = false;
            _as.Play();
        }
        if ((Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("crossX") < 0) && _first == false)
        {
            _first = true;
            _as.Play();
        }
        if (_first)
        {
            _rt.localPosition = new Vector2(-400, transform.localPosition.y);
        }
        else
        {
            _rt.localPosition = new Vector2(400, transform.localPosition.y);
        }

        if (_first == true && Input.GetButtonDown("Submit"))
        {
            _parentAs.Play();
            SceneManager.LoadScene("GameScene");
        }
        if (_first == false && Input.GetButtonDown("Submit"))
        {
            _parentAs.Play();
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
