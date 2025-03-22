using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

/*
Lógica de botones y controles de la sección de créditos. Incluye la navegación y el scroll de los créditos.
Autor: Juan Alfonso Vega Sol
*/

public class CreditosController : MonoBehaviour
{
    [SerializeField] 
    private float velocidad = 10f;
    [SerializeField] 
    private bool accionarLoop = true;
    
    [SerializeField] 
    private float reduccionScroller = 50f; 

    [SerializeField] 
    private float retraso = 0.3f; 
    [SerializeField] 
    private float offset = 50f;

    private UIDocument creditos;
    private Button botonRegreso;

    private ScrollView scrollView;
    private VisualElement contentContainer;
    private VisualElement creditosElem;
    
    private bool setupComplete = false;
    private float alturaCreditos = 0f;
    private float alturaViewPort = 0f;
    private float posicion = 0f;

    private void OnEnable()
    {
        creditos = GetComponent<UIDocument>();
        var root = creditos.rootVisualElement;
        botonRegreso = root.Q<Button>("Regreso");
        scrollView = root.Q<ScrollView>("VistaScroll");
        contentContainer = scrollView.Q("unity-content-container");
        botonRegreso.RegisterCallback<ClickEvent>(evt => CambiarEscena("Menu"));
        scrollView.verticalScrollerVisibility = ScrollerVisibility.Hidden;
        StartCoroutine(DelayedSetup());
    }

    private void CambiarEscena(string escena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(escena);
    }


    private IEnumerator DelayedSetup()
    {
        yield return new WaitForSeconds(retraso);
        creditosElem = contentContainer.Q("texto");
        alturaCreditos = creditosElem.layout.height;
        alturaViewPort = scrollView.layout.height;
        posicion = -offset;
        scrollView.scrollOffset = new Vector2(0, posicion);
        setupComplete = true;
    }

    private void Update()
    {
        if (!setupComplete || scrollView == null) {
            return;
        }

        posicion += velocidad * Time.deltaTime;
        float resetPoint;

        if (accionarLoop)
        {
            resetPoint = alturaCreditos - reduccionScroller;
        }
        else
        {
            resetPoint = alturaCreditos - reduccionScroller;
        }

        if (posicion >= resetPoint)
        {

            if (accionarLoop)
            {
                posicion = -offset;
            }
            else
            {
                posicion = -alturaViewPort;
            }
        }

        scrollView.scrollOffset = new Vector2(0, posicion);
    }
}