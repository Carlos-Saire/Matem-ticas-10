using TMPro;
using UnityEngine;
using System;
public class TimeController : MonoBehaviour
{
    private TMP_Text text;
    public static event Action<float> eventTime;
    [SerializeField] private float time;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        time-=Time.deltaTime;
        if (time <= 0)
        {
            ActiveEventTime();
        }
        text.text=""+(int)time;
    }
    private void ActiveEventTime()
    {
        eventTime?.Invoke(time);
    }
}
