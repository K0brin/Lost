using System;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BattlePartyComponent : MonoBehaviour
{
    [SerializeField] BattleCharacter[] mBattleCharactersPrefabs;

    List<BattleCharacter> mBattleCharacters;

    IViewClient mOwnerViewClient;

    public event Action<BattleCharacter> onBattleCharacterTakeTurn;

    void Awake()
    {
        mOwnerViewClient = GetComponent<IViewClient>();
    }

    public void FinishPrep()
    {
    }
    
    public void UpdateView()
    {
        if (mOwnerViewClient is not null)
        {
            mOwnerViewClient.SetViewtarget(mBattleCharacters[0].transform);
            mOwnerViewClient.ResetViewAngle();
        }
    }

    public List<BattleCharacter> GetBattleCharacters()
    {
        if (mBattleCharacters == null)
        {
            mBattleCharacters = new List<BattleCharacter>();
            foreach (BattleCharacter battleCharacter in mBattleCharactersPrefabs)
            {
                BattleCharacter newBattleCharacter = Instantiate(battleCharacter);
                newBattleCharacter.onTurnStarted += CharacterInTurn;
                mBattleCharacters.Add(Instantiate(battleCharacter));
            }
        }

        return mBattleCharacters;
    }

    private void CharacterInTurn(BattleCharacter character)
    {
        onBattleCharacterTakeTurn?.Invoke(character);
        if(mOwnerViewClient is not null && character)
        {
            mOwnerViewClient.SetViewtarget(character.transform);
        }
    }
}
