using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevel : MonoBehaviour
{
    public GameManager manager;
    public GameObject _UISkillTree;
    public Button firstskill;
    public Button secondskill;
    public Button thirdskill;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OpenSkillTree();

    }

    public void OpenSkillTree()
    {
        if (Input.GetKeyDown(KeyCode.K))
            if(_UISkillTree != null)
                _UISkillTree.SetActive(!_UISkillTree.activeSelf);
        if (_UISkillTree == true) Skilltreeatributes();
    }

    //fazer o level com porcentagem usando um fill
    public void Levelup()
    {
        manager.playerlevel++;
        manager.playerskillpoints = manager.playerskillpoints + manager.playerlevel;
        Skilltreeatributes();
    }

    public void Skilltreeatributes()
    {
        if (manager.playerlevel == 1)
        {
            firstskill.interactable = true;
            secondskill.interactable = true;
            thirdskill.interactable = false;
            Activeskills();
        }
        else if (manager.playerlevel == 2)
        {
            firstskill.interactable = true;
            secondskill.interactable = true;
            thirdskill.interactable = true;
            Activeskills();
        }
    }

    public void Activeskills()
    {
        if (manager.skills[0] == 1)
        {
            firstskill.interactable = true;
            secondskill.interactable = false;
        }
        else if(manager.skills[0] == 2)
        {
            firstskill.interactable = false;
            secondskill.interactable = true;
        }
    }

    public void choseskill(int skill)
    {
        if (skill == 1 && manager.playerskillpoints >= 1)
        {
            manager.playerskillpoints--;
            manager.skills[0] = 1;
            
        }
        if (skill == 2)
        {
            manager.skills[0] = 2;
        }
    }

}
