using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineText : MonoBehaviour
{
    [SerializeField]
    private float m_Delay = 3f;

    private WaitForSeconds m_TimeToWait;
    private Coroutine m_HurtCoroutine;

    private void Start()
    {
        m_TimeToWait = new WaitForSeconds(m_Delay);
        // StartCoroutine(WaitForCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (m_HurtCoroutine != null)
            {
                StopCoroutine(m_HurtCoroutine);
				m_HurtCoroutine = null;
            }
            m_HurtCoroutine = StartCoroutine(HurtSequence());
        }
    }

    private IEnumerator WaitForGinetteToRetire()
    {
        // Ici on réutilise notre WaitForSeconds pour créer moins de déchets
        // Ce n'est pas nécessaire parce que ça ne sauve pas tant de mémoire
        Debug.Log("Before Wait");
        yield return m_TimeToWait;
        Debug.Log("After wait");
    }

    private IEnumerator WaitForCoroutine()
    {
        Debug.Log("J'attends que Ginette prenne sa retraite.");

        yield return StartCoroutine(WaitForGinetteToRetire());

        Debug.Log("Ginette a enfin enfin pris sa retraite");
    }

    private IEnumerator HurtSequence()
    {
        Debug.Log("Red Screen");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("FX Sploosh de sang");
        yield return new WaitForSeconds(1);
        Debug.Log(" OUCH ! ÇA FAIT MAL !");
    }

	private void Die_AnumEvent()
	{
		Debug.Log("I'm dead....");
		StopAllCoroutines();
	}
}
