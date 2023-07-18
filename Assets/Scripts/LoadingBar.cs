using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingBar : MonoBehaviour
{

    public TextMeshProUGUI text;
    public Slider slider;
    public float value;
    public bool start = false;


    private void Update()
    {
        StartCoroutine(bar());
        barAdd();
        value = slider.value;
        text.text = value.ToString() + "%";
        if (value >= 55)
        {
            text.color = new Color(255,255,255);
        } else
        {
            text.color = new Color(0, 0, 0);
        }
        value += 1;
    }

    IEnumerator bar()
    {
        yield return new WaitForSeconds(3);
        start = true;
    }

    public void barAdd()
    {
        if(start)
            slider.value += Random.Range(.1f, 1);

    }
}
