Public Class vMixScripting
  Public Property category As String
  Public Property [function] As String
  Public Property description As String
  Public Property parameters As Parameters
  Public Property examples() As Object
End Class

Public Class Parameters
  Public Property Input As Input
  Public Property Value As Value
  Public Property Channel As Channel
  Public Property Duration As Duration
  Public Property SelectedIndex As Selectedindex
  Public Property SelectedValue As Selectedvalue
  Public Property SelectedName As Selectedname
End Class

Public Class Input
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Value
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
  Public Property composites() As List(Of Composite)
End Class
Public Class Composite
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Channel
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Duration
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Selectedindex
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Selectedvalue
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class Selectedname
  Public Property type As String
  Public Property description As String
  Public Property [optional] As Boolean
End Class

Public Class MethodAutocompleteItem2
  Inherits MethodAutocompleteItem

  Private firstPart As String
  Private lastPart As String

  Public Sub New(ByVal text As String)
    MyBase.New(text)
    Dim i = text.LastIndexOf(".")

    If i < 0 Then
      firstPart = text
    Else
      firstPart = text.Substring(0, i)
      lastPart = text.Substring(i + 1)
    End If
  End Sub

  Public Overrides Function Compare(ByVal fragmentText As String) As CompareResult
    Dim i As Integer = fragmentText.LastIndexOf(".")

    If i < 0 Then
      If firstPart.StartsWith(fragmentText) AndAlso String.IsNullOrEmpty(lastPart) Then Return CompareResult.VisibleAndSelected
    Else
      Dim fragmentFirstPart = fragmentText.Substring(0, i)
      Dim fragmentLastPart = fragmentText.Substring(i + 1)
      If firstPart <> fragmentFirstPart Then Return CompareResult.Hidden
      If lastPart IsNot Nothing AndAlso lastPart.StartsWith(fragmentLastPart) Then Return CompareResult.VisibleAndSelected
      If lastPart IsNot Nothing AndAlso lastPart.ToLower().Contains(fragmentLastPart.ToLower()) Then Return CompareResult.Visible
    End If

    Return CompareResult.Hidden
  End Function

  Public Overrides Function GetTextForReplace() As String
    If lastPart Is Nothing Then Return firstPart
    Return firstPart & "." & lastPart
  End Function

  Public Overrides Function ToString() As String
    If lastPart Is Nothing Then Return firstPart
    Return lastPart
  End Function
End Class



