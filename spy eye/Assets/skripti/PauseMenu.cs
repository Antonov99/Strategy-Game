using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioSource aud;
    public AudioClip knopka;
    public GameObject menu;
    public GameObject build;
    public GameObject shop;
    public GameObject warriorsButton;
    public GameObject warriorsPanel;
    public bool sound;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        sound = true;

    }

    public void pause()
    {
        aud.PlayOneShot(knopka);
        menu.SetActive(true);
        build.SetActive(false);
        shop.SetActive(false);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        aud.PlayOneShot(knopka);
        menu.SetActive(false);
        build.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Zvuk()
    {
        if (!sound)
        {

            AudioListener.volume = 1f;
            sound = true;
        }
        else
        {

            AudioListener.volume = 0f;
            sound = false;
        }
    }

    public void start()
    {
        SceneManager.LoadScene("2");
    }

    public void exit()
    {
        aud.PlayOneShot(knopka);
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        SceneManager.LoadScene("1");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void sh()
    {
        aud.PlayOneShot(knopka);
        shop.SetActive(true);
        build.SetActive(false);
        warriorsButton.SetActive(false);
    }

    public void shKrest()
    {
        aud.PlayOneShot(knopka);
        shop.SetActive(false);
        build.SetActive(true);
        warriorsButton.SetActive(true);
    }

    public void voini()
    {
        aud.PlayOneShot(knopka);
        shop.SetActive(false);
        build.SetActive(false);
        warriorsButton.SetActive(false);
        warriorsPanel.SetActive(true);
    }

    public void voiniZakr()
    {
        aud.PlayOneShot(knopka);
        build.SetActive(true);
        warriorsButton.SetActive(true);
        warriorsPanel.SetActive(false);
    }
}
