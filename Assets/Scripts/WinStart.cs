using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinStart : MonoBehaviour
{
    [SerializeField]
    private Sprite buttonUp;
    [SerializeField]
    private Sprite buttonDown;
    [SerializeField]
    private Image img;
    [SerializeField]
    private Button btn;
    [SerializeField]
    private GameObject go;

    [SerializeField]
    private TextMeshProUGUI shutdown;

    private int counter = 0;


    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void pressBackground()
    {
        btn.image.overrideSprite = buttonUp;
        go.SetActive(false);
    }

    public void Shutdown()
    {
        Application.Quit();
    }

    public void ShutdownWhite()
    {
        shutdown.color = new Color(255, 255, 255);
    }

    public void ShutdownBlack()
    {
        shutdown.color = new Color(0, 0, 0);

    }

    public void pressButton()
    {
        counter++;
        if(counter % 2 == 0)
        {
            btn.image.overrideSprite = buttonUp;
            go.SetActive(false);
        } else
        {
            btn.image.overrideSprite = buttonDown;
            go.SetActive(true);
        }
    }
}
