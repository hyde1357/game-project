using System;
using System.Collections.Generic;

public class StatBase
{
    public float baseValue;
    private readonly List<StatModifier> statModifiers;

    // Get value
    private bool valueUpdated = true;
    private float _value;

    public float Value {
        get {
            if(valueUpdated) { 
                _value = CalculateFinalValue();
                valueUpdated = false;
            }
            return _value;
        }
    }

    // Constructor
    public StatBase(float BaseValue)
    {
        baseValue = BaseValue;
        statModifiers = new List<StatModifier>();
    }

    // Calculations
    public void AddModifier(StatModifier mod)
    {
        valueUpdated = true;
        statModifiers.Add(mod);
    }
    public bool RemoveModifier(StatModifier mod)
    {
        valueUpdated = true;
        return statModifiers.Remove(mod);
    }
    private float CalculateFinalValue()
    {
        float finalValue = baseValue;
        for (int i = 0; i < statModifiers.Count; i++)
        {
            finalValue += statModifiers[i].value;
        }
        
        return (float)Math.Round(finalValue, 4);
    }
}
