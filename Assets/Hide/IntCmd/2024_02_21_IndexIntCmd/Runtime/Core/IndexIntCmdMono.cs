using UnityEngine;

public class IndexIntCmdMono : MonoBehaviour, I_IndexIntCmdSetGet
{

    public IndexIntCmdRef m_indexIntCommand;

    public int GetCommandInt() { return m_indexIntCommand.GetCommandInt(); }
    public int GetIndexInt() { return m_indexIntCommand.GetIndexInt(); }
    public void GetCommandInt(out int value) => value = m_indexIntCommand.GetCommandInt();
    public void GetIndexInt(out int value) => value = m_indexIntCommand.GetIndexInt();

    public void SetIndexInt(int value) => m_indexIntCommand.SetIndexInt(value);

    public void SetCommandInt(int value) => m_indexIntCommand.SetCommandInt(value);

    public void Set(I_IndexIntCmdGet reference)
    {
        SetIndexInt(reference.GetIndexInt());
        SetCommandInt(reference.GetCommandInt());
    }
    public void SetCommand(I_IntCmdGet reference)
    {
        SetCommandInt(reference.GetValue());
    }
    public void SetIndex(I_IntCmdGet reference)
    {
        SetIndexInt(reference.GetValue());
    }
}

