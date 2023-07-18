using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    private TextMeshProUGUI text;
    float time;
    public float speed = 1;

    void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        text.text = hours + ":" + minutes + ":" + seconds;
    }
}