using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTeacherMono_Book : MonoBehaviour
{
    public int m_currentPageIndex;
    public List<BasicTeacherMono_Page> m_pages;
    public BasicTeacherMono_Page m_previousPage;
    public BasicTeacherMono_Page m_currentPage;
    public bool m_loop;
    public void GoAtPageIndex(int pageIndex)
    {
        if (m_pages.Count<1)
            return;
        if (m_loop)
            pageIndex = Mathf.Clamp(pageIndex, 0, m_pages.Count - 1);
        else
        {
            if (pageIndex < 0)
                pageIndex = m_pages.Count - 1;
            if (pageIndex >= m_pages.Count)
                pageIndex = 0;
        }
        m_currentPageIndex = pageIndex;
        m_currentPage = m_pages[pageIndex];
        m_previousPage = m_currentPage;
        if(m_previousPage)
            m_previousPage.SetAsFocused(false);
        if (m_currentPage)
            m_currentPage.SetAsFocused(true);
    }

    public void GoAtPageIndexInInspector()
    {
        GoAtPageIndex(m_currentPageIndex);

    }
    [ContextMenu("Next Page")]
    public void NextPage()
    {
        m_currentPageIndex++;
        GoAtPageIndexInInspector();
    }

    [ContextMenu("Previous Page")]
    public void PreviousPage()
    {
        m_currentPageIndex--;
        GoAtPageIndexInInspector();

    }

    [ContextMenu("Refresh Page")]
    public void RefreshPagesInBook() {
        GetComponentsInChildren(m_pages);
    }
}
