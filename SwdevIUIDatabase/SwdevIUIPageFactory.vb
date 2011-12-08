﻿Imports SwdevIUI

Public Class SwdevIUIPageFactory
    Inherits PageFactory
    Public Overrides Function createPage(ByVal className As String) As SwdevIUI.PageTemplate
        Dim classType As Type = Type.GetType(className)
        Dim page As PageTemplate = CType(Activator.CreateInstance(classType), PageTemplate) 'directcast
        Return page
    End Function
End Class
