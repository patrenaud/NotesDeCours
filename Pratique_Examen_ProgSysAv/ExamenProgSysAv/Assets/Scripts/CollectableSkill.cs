using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectableSkill : MonoBehaviour
{
    public FighterSkill skill;
    
    private void Awake()
    {
        UpdateIcon();
    }

    private void Start()
    {
        if (Game.player.GetComponent<Fighter>().skills.Contains(skill))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos() => UpdateIcon();

    private void UpdateIcon()
    {
        GetComponent<SpriteRenderer>().sprite = skill.Icon;
    }


    private void OnTriggerEnter2D (Collider2D aOther)
    {
        if(aOther.gameObject == Game.player.gameObject)
        {
            Game.player.skills.Add(skill);
            Game.player.RefreshSkillsUI();            
            Game.ui.DisplayDialogBox("You learned the skill : " + skill.name);
            Destroy(gameObject);
        }
    }
}
