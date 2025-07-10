using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternaInterativa : MonoBehaviour
{
    private Animator animator;
    private bool estaAcesa = false;

    public string corLanterna;
    private PuzzleLanternManager puzzleManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("EstáAcesa", estaAcesa);
        puzzleManager = FindObjectOfType<PuzzleLanternManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            estaAcesa = !estaAcesa;
            animator.SetBool("EstáAcesa", estaAcesa);
            Debug.Log("Lanterna " + corLanterna + " -> " + (estaAcesa ? "Acesa" : "Apagada"));

            puzzleManager?.NotificarMudanca(corLanterna, estaAcesa);
        }
    }
}






