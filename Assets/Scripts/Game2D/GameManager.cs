using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private string scene;
    [SerializeField] private int point;
    [SerializeField] private PositionTable positionTable;
    private void TimeGame(float time)
    {
        if (time <= 0)
        {
            positionTable.AddNewScore(point);
            SceneManager.LoadScene(scene);
        }
    }
    private void PointGame(int point)
    {
        this.point += point;
    }
    private void OnEnable()
    {
        TimeController.eventTime += TimeGame;
        PointController.eventPoint += PointGame;
    }
    private void OnDisable()
    {
        TimeController.eventTime -= TimeGame;
        PointController.eventPoint -= PointGame;
    }
}
