using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private GameObject m_Boomrang;
    private Action m_ActionExample;

    private void Update()
    {
        // Use case 1
        if (Input.GetKeyDown(KeyCode.A) && m_Boomrang == null) // On instancie
        {
            m_Boomrang = PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero);
        }

        if (Input.GetKeyDown(KeyCode.D) && m_Boomrang != null) // On ramene nous-même
        {
            PoolManager.Instance.ReturnToPool(EPoolType.Cube, m_Boomrang);
            m_Boomrang = null;
        }


        // Use case 2
        if (Input.GetKeyDown(KeyCode.F))
        {
            // PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero);
            // m_Boomrang.GetComponent<PoolableItems>().StartTimer(2f);
            // == Oneliner
            PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero).GetComponent<PoolableItems>().StartTimer(2f);
        }

        // Use case 3 Avec les actions
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Instancie qqch
            // Instancie S qui call une action qui les retourne dans la pool avec W par action

            // Action privée dans le Player
            // S = Instancie un object de la pool += ReturnToPool
            // W si != null, On remet les object dans la pool
            m_ActionExample += PoolManager.Instance.GetFromPool(EPoolType.Cube, Vector3.zero).GetComponent<PoolableItems>().ReturnToPool;

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (m_ActionExample != null)
            {
                m_ActionExample();
            }
        }
    }
}
