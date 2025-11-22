
using UnityEngine;
[System.Serializable]

//Classe
public class Hero
{
    [SerializeField] private string _nome;
    [SerializeField] private int _hp;
    [SerializeField] private Stats _baseStats;
    [SerializeField] private Stats.ELEMENT _resistance;
    [SerializeField] private Stats.ELEMENT _weakness;
    [SerializeField] private Weapon _weapon;

    //Costruttore
    public Hero(string nome, int hp, Stats baseStats, Stats.ELEMENT resistance, Stats.ELEMENT weakness, Weapon weapon)
    {
        _nome = nome;
        _hp = hp;
        _baseStats = baseStats;
        _resistance = resistance;
        _weakness = weakness;
        _weapon = weapon;
    }

    public string GetName() => _nome;
    public void SetName(string nome) => _nome = nome;

    public int GetHp() => _hp;
    public void SetHp(int hp) => _hp = Mathf.Max(0, hp);
    public Stats GetBaseStats() => _baseStats;
    public void SetbaseStats(Stats baseStats) => _baseStats = baseStats;

    public Stats.ELEMENT GetResistance() => _resistance;
    public void SetResistance(Stats.ELEMENT resistance) => _resistance = resistance;

    public Stats.ELEMENT GetWeakness() => _weakness;
    public void SetWeakness(Stats.ELEMENT weakness) => _weakness = weakness;

    public Weapon GetWeapon() => _weapon;
    public void SetWeapon(Weapon weapon) => _weapon = weapon;

    //Funzioni
    int AddHp(int amount)
    {
        int newHP = _hp + amount;

        SetHp(newHP);

        return newHP;
    }
    
    public int TakeDamage(int damage)
    {
        AddHp(- damage);

        return damage;
    }

    public bool IsAlive()
    {
        if(_hp > 0)
        {
            return true;
        }
        return false;
    }


}