using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    [SerializeField] Ability[] initialAbilities;
    List<Ability> mAbilities = new List<Ability>();

    void Start()
    {
        foreach(Ability initialAbility in initialAbilities)
        {
            GiveAbility(initialAbility);
        }
    }

    private void GiveAbility(Ability abilityDefaultObject)
    {
        Ability newAbility = Instantiate(abilityDefaultObject);
        newAbility.Init(this);
        mAbilities.Add(newAbility);
    }

    internal IEnumerable<Ability> GetAbilities()
    {
        return mAbilities;
    }
}
