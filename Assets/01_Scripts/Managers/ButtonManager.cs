using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioSource srcSfx;

    public void Restart()
    {
        StartCoroutine(LoadGame());
    }

    public void BackToMenu()
    {
        StartCoroutine(LoadMeny());
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        srcSfx.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator LoadMeny()
    {
        srcSfx.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MaiMenu");
    }

}
