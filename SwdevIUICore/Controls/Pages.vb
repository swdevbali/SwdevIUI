Public Class Pages
    Private Shared m_pages As Hashtable = New Hashtable
    Private Shared m_page_class As Hashtable = New Hashtable
    Public Shared m_pageFactoryHash As New Hashtable
    Shared ReadOnly Property Item(ByVal key As String) As PageTemplate
        Get
            'borrowed from http://www.codeproject.com/KB/vb/DynamicFactoryDemo.aspx
            Dim className As String = m_page_class(key)
            If m_pages(key) Is Nothing And className IsNot Nothing Then
                Dim page As PageTemplate
                If className.StartsWith("SwdevIUICore.") Then
                    Dim classType As Type = Type.GetType(className)
                    page = CType(Activator.CreateInstance(classType), PageTemplate) 'directcast
                Else
                    Dim moduleName As String = className.Substring(0, className.IndexOf("."))
                    Dim factory As PageFactory = m_pageFactoryHash(moduleName)
                    page = factory.createPage(className)
                End If
                m_pages.Add(key, page)
            End If
            Return m_pages(key)
        End Get
    End Property

    Shared Sub add(ByVal key As String, ByVal className As String)
        m_page_class.Add(key, className)
    End Sub

    Shared Sub remove(ByVal key As String)
        Dim page As PageTemplate = m_pages(key.ToLower)
        If page IsNot Nothing Then
            'page.Dispose()
            'm_pages.Remove(key)
        End If
        'back to where? home

    End Sub

End Class
