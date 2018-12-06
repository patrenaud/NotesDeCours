using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : Fighter
{
    public CharacterAnimations m_Animations;

    private void Awake()
    {
        m_Animations = GetComponentInChildren<CharacterAnimations>();
    }

    private void Start()
    {
        RefreshSkillsUI();
    }

    private string m_DirectionName;
    
    public void Move(Vector2 direction)
    {
        float inputX = direction.x;// Input.GetAxisRaw("Horizontal");
        float inputY = direction.y;// Input.GetAxisRaw("Vertical");

        //if (!FindObjectOfType<FadeController>().Fading)
        {
            if (inputX > 0)
            {
                m_DirectionName = "right";
                SetAnimWalk();
            }
            else if (inputX < 0)
            {
                m_DirectionName = "left";
                SetAnimWalk();
            }
            else if (inputY > 0)
            {
                m_DirectionName = "up";
                SetAnimWalk();
            }
            else if (inputY < 0)
            {
                m_DirectionName = "down";
                SetAnimWalk();
            }
            else
            {
                SetAnimIdle();
            }
            
            GetComponent<Rigidbody2D>().MovePosition(transform.position + new Vector3(inputX, inputY) * Time.deltaTime * 5);
        }
    }
    
    public void RefreshSkillsUI()
    {   
        IEnumerable<SkillMagic> magicskills = 
        from skill in skills
        where skill is SkillMagic
        let magicskill = skill as SkillMagic // déclaration de variable
        orderby magicskill.MpCost descending
        select magicskill;

        //IEnumerable<SkillAttack> physSkill = Game.player.skills.Where(skill => skill is SkillAttack).Cast<SkillAttack>();
       

        Game.ui.UpdateMagicSkillsMenu(magicskills);
        Game.ui.UpdatePhysicalSkillsMenu(/*skills.Where(skill => skill is SkillAttack).Cast<SkillAttack>()*/skills.OfType<SkillAttack>());
    }

    public void SetAnimWalk()
    {
        m_Animations.SetAnimation("walk_" + m_DirectionName);
    }

    public void SetAnimIdle()
    {
        m_Animations.SetAnimation("idle_" + m_DirectionName);
    }
}
