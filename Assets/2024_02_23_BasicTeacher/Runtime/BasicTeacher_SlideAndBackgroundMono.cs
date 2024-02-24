using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacher_SlideAndBackgroundMono : A_FunctionScratchBlockableMono
{
    public Texture2D m_textureToShow;
    public DisplayType m_displayType;

    public enum DisplayType { 
        Slide, Background
    }



    [ContextMenu("Push")]
    public void Push() {

        BasicTeacherHelpEditorMono  teacher = BasicTeacherHelpEditorMono.TeacherInScene;
        if (teacher)
        {
            if (m_displayType == DisplayType.Background)
                teacher.SetBackground(m_textureToShow);

            else if (m_displayType == DisplayType.Slide)
                teacher.SetSlide(m_textureToShow);
        }
    }

    public override void DoTheScratchableStuffWithoutCoroutine()
    {
        Push();
    }
    
}
