using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] Hero a, b;

    void Update()
    {
        if (a.IsAlive() == false || b.IsAlive() == false)
        {
            return;
        }

        Stats playerAtkA = Stats.Sum(a.GetBaseStats(), a.GetWeapon().GetbonusStats());
        Stats playerAtkB = Stats.Sum(b.GetBaseStats(), b.GetWeapon().GetbonusStats());

        if (playerAtkA.spd == playerAtkB.spd)
        {
            int FirstAtk = Random.Range(0, 2);

            if(FirstAtk == 0)
            {
                Debug.Log(" Attaccante " + a.GetName() + " Difensore " + b.GetName());
                RoundAttack(a, b);

                if (b.IsAlive())
                {
                    RoundAttack(b, a);
                }
            }
            else if(FirstAtk == 1)
            {
                Debug.Log(" Attaccante " + b.GetName() + " Difensore " + a.GetName());
                RoundAttack(b, a);

                if (a.IsAlive())
                {
                    RoundAttack(a, b);
                }
            }
        }
        else if (playerAtkA.spd > playerAtkB.spd)
        {
            Debug.Log(" Attaccante " + a.GetName() + " Difensore " + b.GetName());
            RoundAttack(a, b);

            if (b.IsAlive())
            {
                RoundAttack(b, a);
            }
        }
        else if (playerAtkB.spd > playerAtkA.spd)
        {
            Debug.Log(" Attaccante " + b.GetName() + " Difensore " + a.GetName());
            RoundAttack(b, a);

            if (a.IsAlive())
            {
                RoundAttack(a, b);
            }
        }
    }
     public void RoundAttack(Hero playerA, Hero playerB)
    {
        //Debug.Log($"playerA weakness: {playerA.GetWeakness()}");
        //Debug.Log($"playerB attackElement: {playerB.GetWeapon().Getelem()}");

        if (GameFormulas.HasHit(playerA.GetBaseStats(), playerB.GetBaseStats()) == true)
        {
            if (GameFormulas.HasElementAdvantage(playerA.GetWeapon().Getelem(), playerB) == true)
            {
                Debug.Log(" WEAKNESS ");
                
            }
            else if (GameFormulas.HasElementDisadvantage(playerA.GetWeapon().Getelem(), playerB) == true)
            {
                Debug.Log(" RESIST ");
            }

            playerB.TakeDamage(GameFormulas.CalculateDamage(playerA, playerB));

            Debug.Log(" Il danno subito è " + GameFormulas.CalculateDamage(playerA, playerB));

            if (!playerB.IsAlive())
            {
                Debug.Log(b.GetName() + " ha " + b.GetHp() + " HP " + " Il vincitore è " + a.GetName());
            }

        }
        
    }
}
