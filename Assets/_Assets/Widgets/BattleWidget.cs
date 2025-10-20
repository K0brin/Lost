using UnityEngine;

public class BattleWidget : MonoBehaviour
{
    [SerializeField] CharacterControlWidget mCharacterContorolWidget;
    
    public void SetCharacterControlTarget(BattleCharacter battleCharacter)
    {
        mCharacterContorolWidget.gameObject.SetActive(true);
        mCharacterContorolWidget.SetBattleCharacter(battleCharacter);
    }
}
