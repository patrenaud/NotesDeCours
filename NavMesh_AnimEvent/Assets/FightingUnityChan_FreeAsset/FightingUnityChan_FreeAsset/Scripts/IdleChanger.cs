using UnityEngine;
using System.Collections;

//
// アニメーション簡易プレビュースクリプト
// 2015/4/25 quad arrow
//

// Require these components when using this script
[RequireComponent(typeof(Animator))]

public class IdleChanger : MonoBehaviour
{

    private Animator anim;                      // Animatorへの参照
    private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照
    private AnimatorStateInfo previousState;    // ひとつ前のステート状態を保存する参照
	
	// Ici le type serait le script Enemy et non le GameObject
	private GameObject m_Enemy; 


    // Use this for initialization
    void Start()
    {
        // 各参照の初期化
        anim = GetComponent<Animator>();
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;

    }

    private void Damage_AnimEvent()
    {
        Debug.Log("Damage");
    }

    private void Hit_AnimEvent()
    {
        Debug.Log("UnderSkirt");
		if(m_Enemy != null)
		{
			// m_Enemy.ReceiveDamage(m_KickDamage)
		}
    }

    private void OnTriggerEnter(Collider aOther)
    {
		// J'assigne mon aOther.GetComponent<Enemy>() à ma variable m_Enemy 
		// (seulement si je touche l'ennemi)
    }
    private void OnTriggerExit(Collider aOther)
    {
		// Si mon aOther == m_Enemy.collider, donc m_Enemy = null;

    }


    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 200, 45, 120, 350), "");
        if (GUI.Button(new Rect(Screen.width - 190, 60, 100, 20), "Jab"))
            anim.SetTrigger("Jab");
        if (GUI.Button(new Rect(Screen.width - 190, 90, 100, 20), "Hikick"))
            anim.SetTrigger("Hikick");
        if (GUI.Button(new Rect(Screen.width - 190, 120, 100, 20), "Spinkick"))
            anim.SetTrigger("Spinkick");
        if (GUI.Button(new Rect(Screen.width - 190, 150, 100, 20), "Rising_P"))
            anim.SetTrigger("Rising_P");
        if (GUI.Button(new Rect(Screen.width - 190, 180, 100, 20), "Headspring"))
            anim.SetTrigger("Headspring");
        if (GUI.Button(new Rect(Screen.width - 190, 210, 100, 20), "Land"))
            anim.SetTrigger("Land");
        if (GUI.Button(new Rect(Screen.width - 190, 240, 100, 20), "ScrewKick"))
            anim.SetTrigger("ScrewK");
        if (GUI.Button(new Rect(Screen.width - 190, 270, 100, 20), "DamageDown"))
            anim.SetTrigger("DamageDown");
        if (GUI.Button(new Rect(Screen.width - 190, 300, 100, 20), "Run"))
            anim.SetBool("Run", true);
        if (GUI.Button(new Rect(Screen.width - 190, 330, 100, 20), "Run_end"))
            anim.SetBool("Run", false);


    }
}
