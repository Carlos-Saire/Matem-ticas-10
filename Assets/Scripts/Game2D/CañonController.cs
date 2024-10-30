using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
public class CañonController : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private float launchModifier;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private bool confirmBullet;
    [SerializeField] private float timeBullet;
    [SerializeField] private GameObject point;
    private GameObject[] pointsList;
    [SerializeField] private int pointsCount;
    [SerializeField] private float spaceBetween;
    Vector2 mousePosition;
    private Vector2 direction;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        pointsList = new GameObject[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i] = Instantiate(point, launchPoint.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        Vector2 launchePosition = transform.position;
        Debug.Log(mousePosition);

        direction = mousePosition - launchePosition;

        transform.right = direction;

        for (int i = 0; i < pointsCount; i++)
        {
            pointsList[i].transform.position = CurrentPosition(i * spaceBetween);
        }
    }
    public void PositionMouse(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed&&confirmBullet)
        {
            GameObject proyectile = Instantiate(proyectilePrefab, launchPoint.position, Quaternion.identity);
            proyectile.GetComponent<Rigidbody>().velocity = transform.right * launchModifier;
            StartCoroutine(TimeBullet());
            audioSource.Play();
        }
    }
    private IEnumerator TimeBullet()
    {
        confirmBullet = false;
        yield return new WaitForSeconds(timeBullet);
        confirmBullet = true;
    }
    private Vector2 CurrentPosition(float t)
    {
        return (Vector2)launchPoint.position + (direction.normalized * launchModifier * t) + (Vector2)(0.5f * Physics.gravity * (t * t));
    }
}
