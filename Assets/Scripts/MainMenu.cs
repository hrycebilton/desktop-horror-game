using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource play, background;

    public void Play()
    {
        play.Play();
        background.Stop();
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(1);

    }

    public void Quit()
    {
        Application.Quit();
    }

}