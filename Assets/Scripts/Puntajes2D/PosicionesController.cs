using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PosicionesController : MonoBehaviour
{
    [SerializeField] private TMP_Text[] textos;
    [SerializeField] private PositionTable positionTable;
    [SerializeField] private Button Reintentar;
    [SerializeField] private Button Menu;
    private void Awake()
    {
        Reintentar.onClick.AddListener(OnclickReintentar);
        Menu.onClick.AddListener(OnclickMenu);
    }
    private void Start()
    {
        int numberOfScores = Mathf.Min(textos.Length, positionTable.highScores.Count);

        for (int i = 0; i < numberOfScores; i++)
        {
            textos[i].text = (i + 1) + " : " + positionTable.highScores[i];
        }
        for (int i = numberOfScores; i < textos.Length; i++)
        {
            textos[i].text = (i + 1) + " :";
        }
    }
    private void OnclickReintentar()
    {
        SceneManager.LoadScene("Game2D");
    }
    private void OnclickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
