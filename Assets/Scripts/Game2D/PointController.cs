using UnityEngine;
using System;
public class PointController : MonoBehaviour
{
    [SerializeField] private int point;
    public static event Action<int> eventPoint;
    private void ActiveEventPoint()
    {
        eventPoint?.Invoke(point);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            ActiveEventPoint();
        }
    }
}
