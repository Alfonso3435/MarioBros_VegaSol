using UnityEngine;
using UnityEngine.UIElements;

/*
Lógica de botones y controles del menú principal. Incluye la navegación a las diferentes secciones del menú.
Autor: Juan Alfonso Vega Sol
*/
public class MenuController : MonoBehaviour
{
    private UIDocument menu;
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonVolver;
    private Button botonCerrar;
    private VisualElement contenedorOpciones;
    private VisualElement contenedorAyuda;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("Jugar");
        botonAyuda = root.Q<Button>("Ayuda");
        botonCreditos = root.Q<Button>("Creditos");
        botonVolver = root.Q<Button>("Regreso");
        botonCerrar = root.Q<Button>("Cerrar");

        contenedorOpciones = root.Q<VisualElement>("Opciones");
        contenedorAyuda = root.Q<VisualElement>("ContenedorAyuda");

        contenedorAyuda.style.display = DisplayStyle.None;

        // Callbacks
        botonJugar.RegisterCallback<ClickEvent>(evt => CambiarEscena("Juego"));
        botonCreditos.RegisterCallback<ClickEvent>(evt => CambiarEscena("Creditos"));
        botonAyuda.RegisterCallback<ClickEvent>(MostrarAyuda);
        botonVolver.RegisterCallback<ClickEvent>(VolverAlMenu);
        botonCerrar.RegisterCallback<ClickEvent>(CerrarJuego);
    }

    private void CambiarEscena(string escena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(escena);
    }

    private void MostrarAyuda(ClickEvent evt)
    {
        contenedorOpciones.style.display = DisplayStyle.None;
        contenedorAyuda.style.display = DisplayStyle.Flex;
    }

    private void VolverAlMenu(ClickEvent evt)
    {
        contenedorAyuda.style.display = DisplayStyle.None;
        contenedorOpciones.style.display = DisplayStyle.Flex;
    }

    private void CerrarJuego(ClickEvent evt)
    {
        UnityEditor.EditorApplication.isPlaying = false; 
        Application.Quit(); 
    }
}