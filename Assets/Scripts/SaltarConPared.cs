//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SaltarConPared : MonoBehaviour
//{
//    [Header("Configuracion")]
//    [SerializeField] private float fuerzaSalto = 5f;
//    [SerializeField] private float fuerzaRebote = 2.5f;

//    private bool puedoSaltar = true;
//    private bool saltando = false;
//    private bool tocandoPared = false;

//    private Rigidbody2D miRigidbody2D;

//    private void OnEnable()
//    {
//        miRigidbody2D = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (puedoSaltar)
//            {
//                if (tocandoPared)
//                {
//                    // Salto con rebote de la pared
//                    miRigidbody2D.velocity = new Vector2(-fuerzaRebote, fuerzaSalto);
//                }
//                else
//                {
//                    // Salto normal
//                    miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, fuerzaSalto);
//                }
//                puedoSaltar = false;
//                saltando = true;
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = true;
//            if (saltando)
//            {
//                // Si chocamos con una pared mientras saltamos, permitimos otro salto
//                puedoSaltar = true;
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = false;
//        }
//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SaltarConPared : MonoBehaviour
//{
//    [Header("Configuracion")]
//    [SerializeField] private float fuerzaSalto = 5f;
//    [SerializeField] private float fuerzaRebote = 2.5f;

//    private bool puedoSaltar = true;
//    private bool saltando = false;
//    private bool tocandoPared = false;
//    private bool saltarEnPared = false;

//    private Rigidbody2D miRigidbody2D;

//    private void OnEnable()
//    {
//        miRigidbody2D = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (puedoSaltar)
//            {
//                if (tocandoPared)
//                {
//                    // Salto en diagonal desde la pared
//                    float direccionX = tocandoPared ? -Mathf.Sign(transform.localScale.x) : 0f;
//                    miRigidbody2D.velocity = new Vector2(direccionX * fuerzaRebote, fuerzaSalto);
//                }
//                else
//                {
//                    // Salto normal
//                    miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, fuerzaSalto);
//                }
//                puedoSaltar = false;
//                saltando = true;
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = true;
//            if (saltando)
//            {
//                // Si chocamos con una pared mientras saltamos, permitimos otro salto
//                puedoSaltar = true;
//                saltarEnPared = true;
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = false;
//            saltarEnPared = false;
//        }
//    }
//}





//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SaltarConPared : MonoBehaviour
//{
//    [Header("Configuracion")]
//    [SerializeField] private float fuerzaSalto = 5f;
//    [SerializeField] private float fuerzaRebote = 2.5f;

//    private bool puedoSaltar = true;
//    private bool saltando = false;
//    private bool tocandoPared = false;
//    private bool saltarEnPared = false;
//    private int direccionPared = 1;

//    private Rigidbody2D miRigidbody2D;

//    private void OnEnable()
//    {
//        miRigidbody2D = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            if (puedoSaltar)
//            {
//                if (tocandoPared && saltarEnPared)
//                {
//                    // Salto en diagonal desde la pared
//                    miRigidbody2D.velocity = new Vector2(-direccionPared * fuerzaRebote, fuerzaSalto);
//                    saltarEnPared = false;
//                }
//                else
//                {
//                    // Salto normal
//                    miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, fuerzaSalto);
//                }
//                puedoSaltar = false;
//                saltando = true;
//            }
//        }
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = true;
//            direccionPared = Mathf.RoundToInt(transform.localScale.x);
//            if (saltando)
//            {
//                // Si chocamos con una pared mientras saltamos, permitimos otro salto
//                puedoSaltar = true;
//                saltarEnPared = true;
//            }
//        }
//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Pared"))
//        {
//            tocandoPared = false;
//            saltarEnPared = false;
//        }
//    }
//}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltarConPared : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float fuerzaRebote = 2.5f;

    private bool puedoSaltar = true;
    private bool saltando = false;
    private bool tocandoPared = false;
    private bool saltarEnPared = false;

    private Rigidbody2D miRigidbody2D;

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (puedoSaltar)
            {
                if (tocandoPared && saltarEnPared)
                {
                    // Salto en diagonal desde la pared
                    float direccionX = Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(transform.localScale.x);
                    miRigidbody2D.velocity = new Vector2(direccionX * fuerzaRebote, fuerzaSalto);
                    saltarEnPared = false;
                }
                else
                {
                    // Salto normal
                    miRigidbody2D.velocity = new Vector2(miRigidbody2D.velocity.x, fuerzaSalto);
                }
                puedoSaltar = false;
                saltando = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            tocandoPared = true;
            if (saltando)
            {
                // Si chocamos con una pared mientras saltamos, permitimos otro salto
                puedoSaltar = true;
                saltarEnPared = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pared"))
        {
            tocandoPared = false;
            saltarEnPared = false;
        }
    }
}

