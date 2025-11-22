
[System.Serializable]

//Struct
public struct Stats
{
    public int atk, def, res, spd, crt, aim, eva;

    //Costruttore
    public Stats ( int _atk, int _def, int _res, int _spd, int _crt, int _aim, int _eva )
    {
        atk = _atk;
        def = _def;
        res = _res;
        spd = _spd;
        crt = _crt;
        aim = _aim;
        eva = _eva;    
    }

    //Funzione statica
    public static Stats Sum( Stats stats1, Stats stats2 )
    {
        //Creo un nuovo Stats per sommare le variabili
        return new Stats
            (stats1.atk + stats2.atk,
            stats1.def + stats2.def,
            stats1.res + stats2.res,
            stats1.spd + stats2.spd,
            stats1.crt + stats2.crt,
            stats1.aim + stats2.aim,
            stats1.eva + stats2.eva);
    }

    public enum ELEMENT
    {
        NONE,
        FIRE,
        ICE,
        LIGHTNING
    }
}
