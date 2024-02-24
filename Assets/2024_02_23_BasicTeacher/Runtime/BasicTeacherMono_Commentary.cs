using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicTeacherMono_Commentary : A_CoroutineScratchBlockableMono
{

    public string m_keywords;
    [TextArea(0, 8)]
    public string m_commentary;

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.SetText(m_commentary);
        }
        Debug.Log("Commentary: " + m_commentary, this.gameObject);
    }
    public void OnValidate()
    {
        if (!string.IsNullOrEmpty(m_keywords))
            gameObject.name = "Teacher note:" + m_keywords;
    }
   
}

public class BasicTeacherMono_ProposeSetupClipboard : A_CoroutineScratchBlockableMono
{

    public string m_proposeClipboard;

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.ProposeClipboard(m_proposeClipboard);
        }
    }
}
