namespace BattleRoyale.Models;

using System;
using System.Collections.Generic;

// Classe de base pour tous les personnages
public abstract class Character
{
    public string Name { get; set; }
    public int BaseAttack { get; set; }
    public int BaseDefense { get; set; }
    public int BaseInitiative { get; set; }
    public int Damages { get; set; }
    public int MaximumLife { get; set; }
    public int CurrentLife { get; set; }
    public int TotalAttackNumber { get; set; }
    public int CurrentAttackNumber { get; set; }
    /// <summary>
    /// Pour les vivants sensibles à la douleur.
    /// Si > 0, le personnage ne peut pas attaquer pendant le(s) round(s) indiqués.
    /// </summary>
    public int PainRounds { get; set; } = 0;

    public bool IsAlive => CurrentLife > 0;

    // Pour faciliter l’évolution, on peut ajouter d’autres propriétés (ex. type de dégâts, alignement, etc.)

    public virtual void BeginRound()
    {
        // Si le personnage est affecté par la douleur, il perd ses attaques ce round
        if (PainRounds > 0)
        {
            CurrentAttackNumber = 0;
            // Pour le Guerrier, on réinitialise immédiatement (il ne peut être affecté que pour ce round)
            PainRounds = 0;
        }
        else
        {
            CurrentAttackNumber = TotalAttackNumber;
        }
    }

    public abstract int RollInitiative(Random rand);
    public abstract int RollAttack(Random rand);
    public abstract int RollDefense(Random rand);
}