using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

//StrategyContext拥有IStrategy接口
public class DM03Strategy:MonoBehaviour
{
    private void Start()
    {
        StrategyContext context = new StrategyContext();
        context.strategy = new ConcreteStrategyA();
        context.Calculate();
    }
}

public class StrategyContext
{
    public IStrategy strategy;

    public void Calculate()
    {
        
        strategy.Calculate();
    }

}

public interface IStrategy
{
     void Calculate();
}
public class ConcreteStrategyA : IStrategy
{
    public void Calculate()
    {
        Debug.Log("使用A策略计算。");
    }
}
public class ConcreteStrategyB : IStrategy
{
    public void Calculate()
    {
        Debug.Log("使用B策略计算。");
    }
}