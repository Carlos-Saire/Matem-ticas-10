using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    [SerializeField] private Button jugar;
    [SerializeField] private Button Salir;
    [SerializeField] private string scene;
    private void Awake()
    {
        jugar.onClick.AddListener(OnclikJugar);
        Salir.onClick.AddListener(OnclikSalir);
    }
    private void OnclikSalir()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
    }
    private void OnclikJugar()
    {
        SceneManager.LoadScene(scene);
    }
}
