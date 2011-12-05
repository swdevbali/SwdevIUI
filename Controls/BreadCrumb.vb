Imports System.Drawing
Imports System.Windows.Forms

Public Class BreadCrumb
#Region "Microsoft Inductive User Interface"
    Private m_node As ArrayList = New ArrayList
    Public Event EnterPage As System.EventHandler
    Public Sub clearNode()
        m_node.Clear()
        For i As Integer = Controls.Count - 1 To 0 Step -1
            Dim c As Control = Controls(i)
            If CInt(c.Tag) <> 0 Then
                Controls.Remove(c)
            End If
        Next
    End Sub
    Sub add(ByVal page As PageTemplate)
        'set the home node first
        'home will be change based on user role
        If m_node.Count = 0 Then

            imgHome.Image = page.ImageTitle
            imgHome.ImageAlign = ContentAlignment.MiddleLeft
            linkHome.Text = page.Title
            'linkHome.TextAlign = ContentAlignment.MiddleRight
            imgHome.Tag = 0
            page.Tag = imgHome.Tag 'I modify page tag here
            m_node.Add(page)
            AddHandler imgHome.LinkClicked, AddressOf linkClicked
            AddHandler linkHome.LinkClicked, AddressOf linkClicked
            imgHome.Width = page.ImageTitle.Width + 40
        Else
            'after adding arrow...
            Dim iCount As Integer = m_node.Count
            Dim arrow As Label = New Label()
            'todo : change to wingdings
            arrow.Name = "arrow_" & iCount
            arrow.Left = linkHome.Left + linkHome.Width
            arrow.Top = linkHome.Top
            arrow.Width = 17
            arrow.TextAlign = ContentAlignment.MiddleCenter
            arrow.Text = ">"
            arrow.Tag = iCount
            arrow.AutoSize = True

            Controls.Add(arrow)
            '..add new LinkLabel
            Dim link As LinkLabel = New LinkLabel
            link.Name = "link_" & iCount
            link.Text = page.Title
            ' to use image, we must calc the width of the link label
            Dim img As PictureBox = New PictureBox
            img.Image = page.ImageTitle
            img.SizeMode = PictureBoxSizeMode.AutoSize
            img.Left = arrow.Left + arrow.Width
            img.Top = imgHome.Top
            img.Tag = iCount
            img.Name = "img_" & iCount
            Controls.Add(img)
            'link.ImageAlign = ContentAlignment.MiddleLeft
            'link.Image = page.ImageTitle
            link.TextAlign = ContentAlignment.MiddleRight
            link.Width = page.ImageTitle.Width + 40 'todo : get this text width
            link.Left = img.Left + img.Width
            link.Top = linkHome.Top
            link.Tag = iCount
            link.AutoSize = True
            link.LinkBehavior = LinkBehavior.HoverUnderline
            page.Tag = link.Tag
            AddHandler link.LinkClicked, AddressOf linkClicked
            Controls.Add(link)
            m_node.Add(page)
            Debug.Print(link.Name)
        End If
    End Sub
    Public Sub linkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim link As LinkLabel = sender
        Dim iLink As Integer = link.Tag
        Dim page As PageTemplate
        page = m_node(iLink)

        'remove all future node
        For i As Integer = m_node.Count - 1 To 0 Step -1
            If i = iLink Then
                Exit For
            Else
                If Controls.ContainsKey("arrow_" & i) Then Controls.RemoveByKey("arrow_" & i)
                If Controls.ContainsKey("link_" & i) Then Controls.RemoveByKey("link_" & i)
                If Controls.ContainsKey("img_" & i) Then Controls.RemoveByKey("img_" & i)
                m_node.RemoveAt(i)
            End If
        Next

        'learnt from http://stackoverflow.com/questions/2594608/asp-net-vb-user-control-raising-an-event-on-the-calling-page
        RaiseEvent EnterPage(page, New EventArgs())
        '
    End Sub

    Sub goBack()
        Dim iLast As Integer = m_node.Count - 1
        Controls.RemoveByKey("img_" & iLast)
        Controls.RemoveByKey("link_" & iLast)
        Controls.RemoveByKey("arrow_" & iLast)
        m_node.RemoveAt(iLast)
    End Sub
#End Region



End Class
