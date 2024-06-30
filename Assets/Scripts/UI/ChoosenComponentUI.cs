using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

public class ChoosenComponentUI : MonoBehaviour
{
    public TMP_Text CompinentDescriptionText;
    public TMP_Dropdown ModelChooser;
    public TMP_Text CompinentModelDescriptionText;
    public AllComponentModels ComponentModels;

    public void UpdateUI(ComponentPC componentPC)
    {
        CompinentDescriptionText.text = componentPC.Model.ComponentPC.CompinentDescription;
        ModelChooser.ClearOptions();
        ModelChooser.onValueChanged.RemoveAllListeners();
        List<OptionData> modelChooserOptions = new();
        for (int i = 0; i < ComponentModels.ComponentModelsPC.Count; i++)
        {
            if (ComponentModels.ComponentModelsPC[i].ComponentPC == componentPC.Model.ComponentPC)
            {
                modelChooserOptions.Add(new OptionData(ComponentModels.ComponentModelsPC[i].ComponentModelName));
            }
        }
        ModelChooser.AddOptions(modelChooserOptions);
        ModelChooser.value = modelChooserOptions.IndexOf(modelChooserOptions.Find(x => x.text == componentPC.Model.ComponentModelName));
        ModelChooser.onValueChanged.AddListener(
            (int modelIndex) => 
            {
                componentPC.Model = ComponentModels.ComponentModelsPC.Find(x => x.ComponentModelName == ModelChooser.options[modelIndex].text);
            });
        CompinentModelDescriptionText.text = componentPC.Model.CompinentModelDescription;
    }
}
