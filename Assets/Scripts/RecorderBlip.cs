using UnityEngine;

public class RecorderBlip : MonoBehaviour
{

    public GameObject blip;

    private static bool isDone = false;

    public static bool isOn = false;

    public float timer;

    void Update()
    {
        Mathf.Clamp(timer, 0, 1);
        timer += Time.deltaTime;
        if (timer >= 0.3 && !isDone)
        {
            blip.SetActive(true);
        }
        if (timer >= 1 && !isDone)
        {
            blip.SetActive(false);
            timer = 0;
        }
    }

}