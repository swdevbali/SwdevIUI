Imports System.Windows.Forms
Imports System.Drawing

'solved simply by using FlowLayoutPanel, thanks http://visualbasic.about.com/od/usingvbnet/a/tloflopnl.htm
Public Class TabHeader
    Dim hashTab As New Hashtable
    Dim hashLink As New Hashtable
    Dim lastLink As LinkLabel
    Dim closeButton As Button
    Dim hoverLink As LinkLabel
    Event EnterPage(ByVal page As PageTemplate, ByVal eventArgs As EventArgs)

    Event EnterHomePage()

    Sub add(ByVal view As PageTemplate)
        If hashTab(view.Title) IsNot Nothing Then
            Return
        End If
        hashTab.Add(view.Title, view)

        Dim linkTab As New LinkLabel

        linkTab.Text = view.Title
        linkTab.LinkBehavior = LinkBehavior.NeverUnderline
        linkTab.TextAlign = Drawing.ContentAlignment.MiddleCenter
        linkTab.BackColor = Drawing.Color.LightGray '.Transparent
        AddHandler linkTab.MouseEnter, AddressOf linkHoverIn
        AddHandler linkTab.MouseLeave, AddressOf linkHoverOut
        AddHandler linkTab.Click, AddressOf linkClicked
        AddHandler linkTab.MouseHover, AddressOf linkHover
        hashLink.Add(view.Title, linkTab)
        flowPanel.Controls.Add(linkTab)

    End Sub
    Sub linkHoverIn(ByVal sender As Object, ByVal e As EventArgs)
        Dim linkTab As LinkLabel = sender
        If linkTab IsNot lastLink Then linkTab.BackColor = Drawing.Color.White
        closeButton.Location = New Point(linkTab.Left + linkTab.Width - closeButton.Width + 5, Me.Top + linkTab.Top + 2)
        closeButton.Visible = True
        hoverLink = sender
    End Sub
    Sub linkHover(ByVal sender As Object, ByVal e As EventArgs)
        closeButton.Focus()
    End Sub
    Sub linkHoverOut(ByVal sender As Object, ByVal e As EventArgs)
        Dim linkTab As LinkLabel = sender
        If lastLink IsNot linkTab Then linkTab.BackColor = Drawing.Color.LightGray 'Transparent
        'closeButton.Visible = False
    End Sub
    Sub clearNode()
        flowPanel.Controls.Clear()
        lastLink = Nothing
        closeButton.Visible = False

    End Sub

    Sub goBack()
        'in using tab page, back may not defined
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
        If lastLink IsNot Nothing Then lastLink.BackColor = Drawing.Color.LightGray 'Transparent
        Dim link As LinkLabel = hashLink(page.Title)
        If link Is Nothing Then
            add(page)
            link = hashLink(page.Title)
        End If
        link.BackColor = Drawing.Color.White 'Yellow
        lastLink = link
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

       

    End Sub
    Sub setCloseButton(ByVal b As Button)
        closeButton = b
        closeButton.Visible = False
        AddHandler closeButton.Click, AddressOf closingTab
        AddHandler closeButton.MouseLeave, AddressOf closeButtonMouseLeave
    End Sub
    Sub closeButtonMouseLeave()
        closeButton.Visible = False
    End Sub
    Sub closingTab()
        Dim key As String = hoverLink.Text
        hashTab.Remove(hoverLink.Text)
        Dim linkRemove As LinkLabel = hashLink(key)
        linkRemove.Dispose()
        hashLink.Remove(key)
        Pages.remove(key)
        flowPanel.Controls.Remove(linkRemove)
        RaiseEvent EnterHomePage()
    End Sub
End Class
