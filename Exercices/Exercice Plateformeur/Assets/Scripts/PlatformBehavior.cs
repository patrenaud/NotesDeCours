using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D aOther)
    {
        Debug.Log("Platform Hit");
        if (aOther.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            gameObject.GetComponentInChildren<AreaEffector2D>().enabled = true;
            Destroy(aOther.gameObject);
			gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }
}
