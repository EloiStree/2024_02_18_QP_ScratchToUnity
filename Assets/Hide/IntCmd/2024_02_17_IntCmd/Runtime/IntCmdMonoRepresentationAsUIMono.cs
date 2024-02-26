using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntCmdMonoRepresentationAsUIMono : MonoBehaviour
{

    public IntCmdMonoRepresentationMono m_representationSource;



    public Text m_debugRaw;
    public Image m_debugIntAsColor;

    private void Update()
    {

       
        m_debugRaw.text = string.Format("{0:000000000000}\n{1}\n{2}\nC# {3}\n|\nPython Javascript {4}",
            m_representationSource.m_int,
            m_representationSource.m_structure,
            m_representationSource.m_binarySplitByByte,
            m_representationSource.littleEndianBytesAsString,
            m_representationSource.bigEndianBytesAsString
            //m_representationSource.littleEndianBytesAs255String,
            //m_representationSource.bigEndianBytesAs255String
            );
    }

}
