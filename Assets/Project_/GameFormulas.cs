
using Unity.VisualScripting;
using UnityEngine;
public static class GameFormulas
{
    public static bool HasElementAdvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        Stats.ELEMENT weakness = defender.GetWeakness();

        //Debug.Log($"Comparing {attackElement} with defender weakness {weakness}");

        if (attackElement == weakness)
        {
            return true;
        }
        return false;
    }

    public static bool HasElementDisadvantage(Stats.ELEMENT attackElement, Hero defender)
    {
        Stats.ELEMENT resistance = defender.GetResistance();

        if (attackElement == resistance)
        {
            return true;
        }
        return false;
    }

    public static float EvaluateElementalModifier(Stats.ELEMENT attackElement, Hero defender)
    { 
        bool vantaggio = HasElementAdvantage(attackElement, defender);
        bool svantaggio = HasElementDisadvantage(attackElement, defender);

        if (vantaggio == true)
        {
            return 1.5f;
        }
        else if (svantaggio == true)
        {
            return 0.5f;
        }
        return 1f;
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.aim - defender.eva;

        int atk = Random.Range(0, 100);

        if (atk > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        return true;
    }

    public static bool IsCrit(int critValue)
    {
        int critico = Random.Range(0, 100);

        if(critico < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        return false;
    }
    //operatore ternario variabile vuota = condizione ? defstats.def : defstats.res è uguale a if else
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats atkstats = Stats.Sum(attacker.GetBaseStats(), attacker.GetWeapon().GetbonusStats());
        Stats defstats = Stats.Sum(defender.GetBaseStats(), defender.GetWeapon().GetbonusStats());

        Weapon attackerWeapon = attacker.GetWeapon();
        Weapon.DAMAGE_TYPE dmgType = attackerWeapon.GetdmgType();

        int selectedDef = dmgType == Weapon.DAMAGE_TYPE.PHYSICAL ? defstats.def : defstats.res;

        int baseDamage = atkstats.atk - selectedDef;

        int newDamage = (int) (baseDamage * EvaluateElementalModifier(attacker.GetWeapon().Getelem(), defender));

        int crtDmg = IsCrit(attacker.GetBaseStats().crt) == true ? newDamage *= 2 : newDamage;

        if ( newDamage < 0 )
        {
            newDamage = 0;
        }

        return newDamage;
    }
}

    

