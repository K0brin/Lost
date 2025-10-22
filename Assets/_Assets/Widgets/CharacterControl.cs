using TMPro;
using UnityEngine;

public class CharacterControlWidget : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mCharacterNametext;
    internal void SetBattleCharacter(BattleCharacter battleCharacter)
    {
        mCharacterNametext.SetText(battleCharacter.Name);
    }

}
