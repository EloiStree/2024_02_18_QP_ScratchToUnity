using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IntCmdSourceRegisterDebugListMono : MonoBehaviour
{

    public IntCmdSourceRegisterMono m_source;
    public List<IntCmdTimedWithSource> m_valueInRegister = new List<IntCmdTimedWithSource>();
    public void Refresh()
    {
        m_valueInRegister = m_source.m_register.m_intCmdState.Values.ToList();
    }
    public bool m_useUpdateRefresh=true;
    public void Update()
    {
        if(m_useUpdateRefresh)
        Refresh();
    }
}
