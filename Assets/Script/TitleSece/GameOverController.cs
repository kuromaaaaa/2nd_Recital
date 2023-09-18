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
    float _Timer;
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
        _Timer = Time.deltaTime;
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
        if (_first == false && Input.GetButtonDown("Submit") || _Timer > 20)
        {
            _parentAs.Play();
            SceneManager.LoadScene("TitleScene");
        }
    }
}
