Public Class Pages
    Private Shared m_pages As Hashtable = New Hashtable
    Private Shared m_page_class As Hashtable = New Hashtable
    Public Shared m_pageFactoryHash As New Hashtable
    Shared ReadOnly Property Item(ByVal key As String) As PageTemplate
        Get
            'at last, only instantiate when needed
            'borrowed from http://www.codeproject.com/KB/vb/DynamicFactoryDemo.aspx
            Dim className As String = m_page_class(key)
            If m_pages(key) Is Nothing And className IsNot Nothing Then
                'Dim classType As Type = Type.GetType(className)
                'Dim page As PageTemplate = CType(Activator.CreateInstance(classType), PageTemplate) 'directcast
                'AddHandler page.MouseDown, AddressOf EntryWindow.Form1_MouseDown 'so we can drag window by dragging the page

                Dim page As PageTemplate
                If className.StartsWith("SwdevIUI") Then
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

End Class
