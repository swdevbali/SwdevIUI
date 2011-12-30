Imports System.Windows.Forms

Public Class TabHeader
    Dim hashTab As New Hashtable
    Dim hashLink As New Hashtable
    Dim lastLink As LinkLabel
    Event EnterPage(ByVal page As PageTemplate, ByVal eventArgs As EventArgs)

    Sub add(ByVal view As PageTemplate)
        If hashTab(view.Title) IsNot Nothing Then
            Return
        End If
        hashTab.Add(view.Title, view)

        Dim linkTab As New LinkLabel

        linkTab.Text = view.Title
        linkTab.Dock = DockStyle.Fill
        linkTab.TextAlign = Drawing.ContentAlignment.MiddleCenter
        linkTab.BackColor = Drawing.Color.Transparent
        AddHandler linkTab.MouseEnter, AddressOf linkHoverIn
        AddHandler linkTab.MouseLeave, AddressOf linkHoverOut
        AddHandler linkTab.Click, AddressOf linkClicked
        hashLink.Add(view.Title, linkTab)
        If tablePage.ColumnCount = 2 Then 'first we have one column. it's the minimum
            tablePage.Controls.Add(linkTab, tablePage.ColumnCount - 2, 0)
            tablePage.ColumnStyles(tablePage.ColumnCount - 2).SizeType = SizeType.Absolute
            tablePage.ColumnStyles(tablePage.ColumnCount - 2).Width = 100
            tablePage.ColumnCount = tablePage.ColumnCount + 1
           
        Else
         
            tablePage.Controls.Add(linkTab, tablePage.ColumnCount - 2, 0)
            tablePage.ColumnCount = tablePage.ColumnCount + 2
            ' tablePage.ColumnStyles(tablePage.ColumnCount - 2).SizeType = SizeType.Absolute
            'tablePage.ColumnStyles(tablePage.ColumnCount - 2).Width = 120
        End If

    End Sub
    Sub linkHoverIn(ByVal sender As Object, ByVal e As EventArgs)
        Dim linkTab As LinkLabel = sender
        linkTab.BackColor = Drawing.Color.White
    End Sub
    Sub linkHoverOut(ByVal sender As Object, ByVal e As EventArgs)
        Dim linkTab As LinkLabel = sender
        If lastLink IsNot linkTab Then linkTab.BackColor = Drawing.Color.Transparent
    End Sub
    Sub clearNode()
        tablePage.Controls.Clear()
        tablePage.ColumnCount = 2
        tablePage.ColumnStyles(tablePage.ColumnCount - 2).SizeType = SizeType.Absolute
        tablePage.ColumnStyles(tablePage.ColumnCount - 2).Width = 120
        lastLink = Nothing
    End Sub

    Sub goBack()
        'Throw New NotImplementedException
    End Sub
    'activate tab and select it (display its corrsponding page)
    Sub linkClicked(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim link As LinkLabel = sender
        Dim page As PageTemplate
        page = hashTab(link.Text)
        selectTab(page)
        RaiseEvent EnterPage(page, New EventArgs()) ' http://stackoverflow.com/questions/2594608/asp-net-vb-user-control-raising-an-event-on-the-calling-page
    End Sub
    'activate tab, but not select it.
    Sub selectTab(ByVal page As PageTemplate)
        If lastLink IsNot Nothing Then lastLink.BackColor = Drawing.Color.Transparent
        Dim link As LinkLabel = hashLink(page.Title)
        link.BackColor = Drawing.Color.Yellow
        lastLink = link
    End Sub

End Class
