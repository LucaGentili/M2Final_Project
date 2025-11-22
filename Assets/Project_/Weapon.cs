
using UnityEngine;

[System.Serializable]

public class Weapon
{
    public enum DAMAGE_TYPE
    {
        PHYSICAL,
        MAGICAL
    }

    [SerializeField] private string _name;
    [SerializeField] private DAMAGE_TYPE _dmgType;
    [SerializeField] private Stats.ELEMENT _elem;
    [SerializeField] private Stats _bonusStats;

    // Costruttore
    public Weapon(string name, DAMAGE_TYPE dmgType, Stats.ELEMENT elem, Stats bonusstats)
    {
        _name = name;
        _dmgType = dmgType;
        _elem = elem;
        _bonusStats = bonusstats;
    }

    public string GetName() => _name;
    public void SetName(string name) => _name = name;


    public DAMAGE_TYPE GetdmgType() => _dmgType;
    public void SetdmgType(DAMAGE_TYPE dmgType) => _dmgType = dmgType;  


    public Stats.ELEMENT Getelem() => _elem;
    public void Setelem(Stats.ELEMENT elem) => _elem = elem;

    public Stats GetbonusStats() => _bonusStats;
    public void SetbonusStats(Stats bonusStats) => _bonusStats = bonusStats;
}