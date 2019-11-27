using System;
using System.Collections.Generic;
using System.Text;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldiers = new List<ICharacter>();


    public override void Init()
    {
        base.Init();
    }

    public void AddEnemy(IEnemy enemy)
    {
        if (enemy != null & mEnemys.Contains(enemy) == false)
        {
            mEnemys.Add(enemy);
        }
    }

    public void RemoveEnemy(IEnemy enemy)
    {
        if (enemy != null & mEnemys.Contains(enemy) == true)
        {
            mEnemys.Remove(enemy);
        }
    }

    public void AddSoldier(ISoldier soldier)
    {
        if (soldier != null & mSoldiers.Contains(soldier) == false)
        {
            mSoldiers.Add(soldier);
        }
    }

    public void RemoveSoldier(ISoldier soldier)
    {
        if (soldier != null & mSoldiers.Contains(soldier) == true)
        {
            mSoldiers.Remove(soldier);
        }
    }

    public override void Update()
    {
        UpdateEnemy();
        UpdateSoldier();
        RemoveCharacterIsKilled();
    }

    private void UpdateEnemy()
    {
        foreach (IEnemy enemy in mEnemys)
        {
            enemy.Update();
            enemy.UpdateFSMAI(mSoldiers);
        }
    }

    private void UpdateSoldier()
    {
        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.Update();
            soldier.UpdateFSMAI(mEnemys);
        }
    }

    private void RemoveCharacterIsKilled()
    {
        //foreach (ICharacter enemy in mEnemys)
        //{
        //    if (enemy.canDestroy)
        //    {
        //        enemy.Release();
        //        //遍历时不可对遍历对象进行修改
        //        mEnemys.Remove(enemy);
        //    }
        //}

        List<ICharacter> canDestroyEnemys = new List<ICharacter>();
        foreach (ICharacter enemy in mEnemys)
        {
            if (enemy.canDestroy)
            {
                //遍历时不可对[遍历对象]进行修改
                //mEnemys.Remove(enemy);
                canDestroyEnemys.Add(enemy);
            }
        }

        foreach (ICharacter item in canDestroyEnemys)
        {
            item.Release();
            mEnemys.Remove(item);

        }
        
        canDestroyEnemys.Clear();
        foreach (ICharacter soldier in mSoldiers)
        {
            if (soldier.canDestroy)
            {
                //遍历时不可对[遍历对象]进行修改
                //mEnemys.Remove(enemy);
                canDestroyEnemys.Add(soldier);
            }
        }

        foreach (ICharacter item in canDestroyEnemys)
        {
            item.Release();
            mSoldiers.Remove(item);
        }

    }

    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (IEnemy enemy in mEnemys)
        {
            enemy.RunVisitor(visitor);
        }

        foreach (ISoldier soldier in mSoldiers)
        {
            soldier.RunVisitor(visitor);
        }
    }
}
