using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Palanca : MonoBehaviour
{
    [SerializeField] private UnityEvent onPalancaTriggered;

    private bool palancaOn = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!palancaOn)
            {
                palancaOn = true;
                onPalancaTriggered.Invoke();
            }
        }
    }
}
