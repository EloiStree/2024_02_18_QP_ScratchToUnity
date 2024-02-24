using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityBasicUIToIntCmdMono_FullSlider : MonoBehaviour
{

    public AbstractIntCmdHolderMono m_toAffect;

    public Slider[] m_unitySlider;

    public List<UI2IntCmd.UIF_Slider09> m_slider09 = new List<UI2IntCmd.UIF_Slider09>();

    [ContextMenu("Refresh List")]
    public void RefreshList() {
        m_slider09.Clear();
        int i = 0;
        foreach (var item in m_unitySlider)
        {

            m_slider09.Add(new UI2IntCmd.UIF_Slider09() { m_uiElement = item,
                m_digit = i >= 10 ? IntCmdDigitEnum.DigitLeftRight1:
                           IntCmdDigitUtility.GetDigitLeftToRight(i)
            }); ;
            i++;
        }

    }
}
