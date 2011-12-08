Imports System.Windows.Forms

Public Class PageTemplate
    Private m_imageTitle As System.Drawing.Image
    Private m_Tit
    Private m_title As String
    Private m_lvPag
    Private m_lvPageActivities As ListView
    Public Property lvPageActivities() As ListView
        Get
            Return m_lvPageActivities
        End Get
        Set(ByVal value As ListView)
            'default value
            value.Columns.Clear()
            value.Columns.Add("Task")
            value.Columns.Add("Description")
            value.BorderStyle = Windows.Forms.BorderStyle.None
            value.Columns(0).Width = 200
            value.Columns(1).Width = value.Width - value.Columns(0).Width
            value.View = View.Details
            value.ShowGroups = True
            m_lvPageActivities = value
        End Set
    End Property

   
    Public Property Title() As String
        Get
            Return m_title
        End Get
        Set(ByVal value As String)
            m_title = value
        End Set
    End Property
    Public Property ImageTitle As System.Drawing.Image
        Get
            Return m_imageTitle
        End Get
        Set(ByVal value As System.Drawing.Image)
            m_imageTitle = value
        End Set
    End Property

    Overridable Sub refreshDataGrid()
     
    End Sub

End Class
