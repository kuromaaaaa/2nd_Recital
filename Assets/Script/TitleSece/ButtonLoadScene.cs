using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : MonoBehaviour
{

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
