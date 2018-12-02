using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace HumanStats
{
    [System.Serializable]
    public class HumanStat
    {
        public float BaseValue;
        public float Value
        {
            get
            {
                if (isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }
        }

        protected bool isDirty = true;
        protected float _value;

        protected readonly ReadOnlyCollection<StatModifier> StatModifiers;
        protected readonly List<StatModifier> statModifiers;

        protected float lastBaseValue = float.MinValue;

        public HumanStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }
        public HumanStat(float baseValue) : this()
        {
            BaseValue = baseValue;
        }

        public virtual void AddModifier(StatModifier mod)
        {
            statModifiers.Add(mod);
            isDirty = true;
            statModifiers.Sort(CompareModifierOrder);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;
            else
                return 0;
        }

        protected virtual bool RemoveModifier(StatModifier mod)
        {

            if (statModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;

            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];

                if (mod.Type == StatModType.Flat)
                    finalValue += mod.Value;
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;

                    if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type == StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMul)
                    finalValue *= 1 + mod.Value;
            }

            return (float)Math.Round(finalValue, 4);
        }
    }
}