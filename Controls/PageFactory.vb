Public Class PageFactory

    Overridable Function createPage(ByVal className As String) As PageTemplate
        Return Nothing
    End Function

End Class
