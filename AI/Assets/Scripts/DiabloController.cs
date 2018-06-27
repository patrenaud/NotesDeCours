using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DiabloController : MonoBehaviour
{
    public NavMeshAgent m_Agent;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray rayon = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hitinfo;
            if (Physics.Raycast(rayon, out Hitinfo, 100f, LayerMask.GetMask("Ground")))
            {
                m_Agent.SetDestination(Hitinfo.point);
            }
        }
    }
}
