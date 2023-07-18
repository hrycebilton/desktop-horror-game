using UnityEngine;
using TMPro;

public class ClockTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timetxt;
    void Update()
    {
        timetxt.text = System.DateTime.Now.ToString("h:mm tt");
    }
}
