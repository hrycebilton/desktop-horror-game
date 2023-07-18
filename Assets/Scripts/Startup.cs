using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Startup : MonoBehaviour
{

    [SerializeField]
    private GameObject text, blip, video;

    [SerializeField]
    private VideoPlayer vp;

    private static bool isDone = false;

    public static bool isOn = false;

    public float timer;


    void Start()
    {
        video.SetActive(false);
        vp.loopPointReached += CheckOver;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.3 && !isDone)
        {
            blip.SetActive(true);
        }
        if (timer >= .7 && !isDone)
        {
            blip.SetActive(false);
            timer = 0;
        }
        StartCoroutine(stop());
    }


    IEnumerator stop()
    {
        yield return new WaitForSeconds(5);
        video.SetActive(true);
        isDone = true;
        blip.SetActive(false);
        text.SetActive(false);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(3);
    }
}