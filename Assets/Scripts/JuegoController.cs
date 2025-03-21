using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class JuegoController : MonoBehaviour
{
    private UIDocument juego;
    private Button botonRegreso;

    void OnEnable(){
        juego = GetComponent<UIDocument>();
        var root = juego.rootVisualElement;
        botonRegreso = root.Q<Button>("Regreso");

        //Callbacks
        botonRegreso.RegisterCallback<ClickEvent, String>(Regresar, "Menu");
    }

    private void Regresar(ClickEvent evt, String escena)
    {
        SceneManager.LoadScene(escena);
    }

}
