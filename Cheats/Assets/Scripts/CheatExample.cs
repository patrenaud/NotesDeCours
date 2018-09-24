#if UNITY_EDITOR
    #define SAM_LAP
#endif


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatExample : MonoBehaviour
{
    
	private void Start ()
    {

#if UNITY_CHEATS
        Debug.Log("That cheat!");
#endif
        Debug.Log("That other shit...");




#if UNITY_EDITOR
        Debug.Log("Editor");
#else
        Debug.Log("StandAlone");
#endif




#if SAM_LAP
        Debug.Log("Unreal is too haaaaard");
#endif
    }
	

	private void Update ()
    {
		
	}
}
