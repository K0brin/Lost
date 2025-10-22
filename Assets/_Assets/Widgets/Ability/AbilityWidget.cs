using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityWidget : MonoBehaviour
{
    Button mButton;
    void Awake()
    {
        mButton = GetComponent<Button>();
        mButton.onClick.AddListener(ActivateAbility);
    }
    Ability mAbility;
    public void SetAbility(Ability ability)
    {
        mAbility = ability;
        GetComponentInChildren<TextMeshProUGUI>().text = mAbility.mAbilityName;
    }
    void ActivateAbility()
    {
        mAbility.ActivateAbility();
    }
}
