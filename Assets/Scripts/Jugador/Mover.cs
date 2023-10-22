/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;
    
    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private CircleCollider2D miCollider2D;

    private int saltarMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();

        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<CircleCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    // codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxisRaw("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX > 0;
        miAnimator.SetInteger("Velocidad", velocidadX);

        miAnimator.SetBool("EnAire", !EnContactoConPlataforma());
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miRigidbody2D.IsTouchingLayers(saltarMask);
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2D;
    private Jugador jugador;

    private int saltarMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
        jugador = GetComponent<Jugador>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxisRaw("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX > 0;
        miAnimator.SetInteger("Velocidad", velocidadX);

        miAnimator.SetBool("EnAire", !EnContactoConPlataforma());

    }

    private void FixedUpdate()
    {
       miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.VelocidadHorizontal);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }
}
