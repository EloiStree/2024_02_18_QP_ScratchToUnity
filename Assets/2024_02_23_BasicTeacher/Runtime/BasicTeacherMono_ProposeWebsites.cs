using System.Collections;

public class BasicTeacherMono_ProposeWebsites : A_CoroutineScratchBlockableMono
{

    public string[] m_proposedUrls;

    public override IEnumerator DoTheScratchableStuff()
    {
        PushCommentary();
        yield return null;
    }

    public void PushCommentary()
    {

        if (BasicTeacherHelpEditorMono.TeacherInScene)
        {
            BasicTeacherHelpEditorMono.TeacherInScene.ProposeWebsites(m_proposedUrls);
        }
    }
    
}
