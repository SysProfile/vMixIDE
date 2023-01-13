Imports System.IO
Imports System.Net.Http
Imports System.Text.Json

Public Class frmMain
  Private ustCountFunctions As UShort
  Private WithEvents popupMenu As AutocompleteMenu
  Private vMixFuncList, vMixScriptList As List(Of vMixScripting)
  Private xmlDoc As XmlDocument = Nothing
  Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Dim blnCheckOnSite As Boolean = False
    If Not IO.File.Exists(Application.StartupPath & "vMixListCount.txt") Then
      blnCheckOnSite = True
      IO.File.WriteAllText(Application.StartupPath & "vMixListCount.txt", String.Empty)
    Else
      Dim fiData As New FileInfo(Application.StartupPath & "vMixListCount.txt")
      If DateDiff(DateInterval.Day, fiData.LastWriteTime, Now) > 30 Then
        IO.File.Delete(Application.StartupPath & "vMixListCount.txt")
        blnCheckOnSite = True
      End If
    End If
    If blnCheckOnSite Then
      Dim strTask As Task(Of String) = GetDataFromWeb("https://raw.githubusercontent.com/jensstigaard/vmix-function-list/1c695977f93fd7a41cc2f84a2b85864df8ceafde/rendered/count.txt")
      ustCountFunctions = CType(strTask.Result, UShort)
      IO.File.WriteAllText(Application.StartupPath & "vMixListCount.txt", strTask.Result)
      Dim strJSon As Task(Of String) = GetDataFromWeb("https://raw.githubusercontent.com/jensstigaard/vmix-function-list/master/rendered/list.json")
      IO.File.WriteAllText(Application.StartupPath & "vMixFuncList.json", strJSon.Result.Replace("Duraion", "Duration").Replace("SelectName", "SelectedName"))
    End If
    vMixFuncList = JsonSerializer.Deserialize(Of List(Of vMixScripting))(File.ReadAllText(Application.StartupPath & "vMixFuncList.json"))
    vMixFuncList.Sort(Function(x As vMixScripting, y As vMixScripting)
                        If (x.category & "&" & x.function) Is Nothing AndAlso (y.category & "&" & y.function) Is Nothing Then
                          Return 0
                        ElseIf (x.category & "&" & x.function) Is Nothing Then
                          Return -1
                        ElseIf (y.category & "&" & y.function) Is Nothing Then
                          Return 1
                        Else
                          Return (x.category & "&" & x.function).CompareTo((y.category & "&" & y.function))
                        End If
                      End Function)
    vMixScriptList = JsonSerializer.Deserialize(Of List(Of vMixScripting))(File.ReadAllText(Application.StartupPath & "vMixScriptList.json"))
    popupMenu = New AutocompleteMenu(txtIDE) With {
      .SearchPattern = "[\w\.]",
      .AllowTabKey = True,
      .AlwaysShowTooltip = True,
      .AutoClose = False
    }
    Dim items As New List(Of AutocompleteItem)
    For ustCnt As UShort = 0 To vMixFuncList.Count - 1
      items.Add(New MethodAutocompleteItem2("vmix." & vMixFuncList(ustCnt).function))
      items(ustCnt).ToolTipTitle = vMixFuncList(ustCnt).category
      items(ustCnt).ToolTipText = vMixFuncList(ustCnt).description
    Next
    items.Add(New MethodAutocompleteItem2("vb.Input"))
    For ustCnt As UShort = 0 To vMixScriptList.Count - 1
      items.Add(New MethodAutocompleteItem2("vb." & vMixScriptList(ustCnt).function))
      items(ustCnt).ToolTipTitle = vMixScriptList(ustCnt).category
      items(ustCnt).ToolTipText = vMixScriptList(ustCnt).description
    Next
    popupMenu.Items.SetAutocompleteItems(items)
  End Sub
  Private Sub popupMenu_Selected(sender As Object, e As SelectedEventArgs) Handles popupMenu.Selected
    If e.Item.Text.StartsWith("vb.Input.") Then
      Dim vMixF As vMixScripting = vMixScriptList.Find(Function(c) c.function = e.Item.Text.Replace("vb.", String.Empty))
      Dim strAPI As String = "'" & vMixF.description & ControlChars.CrLf & vMixF.category
      For bteFields As Byte = 0 To vMixF.parameters.Value.composites.Count - 1
        strAPI &= "." & vMixF.parameters.Value.composites(bteFields).type & "(" & ControlChars.Quote & vMixF.parameters.Value.composites(bteFields).description & ControlChars.Quote & ")"
      Next
      Dim uint As List(Of Integer) = txtIDE.FindLines(e.Item.Text, System.Text.RegularExpressions.RegexOptions.None)
      txtIDE.Text = txtIDE.Text.Replace(e.Item.Text, strAPI)
      txtIDE.SetSelectedLine(uint(0) + vMixF.description.Split("\n").Count + 2)
    ElseIf e.Item.Text.StartsWith("vmix.") Then
      Dim vMixF As vMixScripting = vMixFuncList.Find(Function(c) c.function = Split(e.Item.Text, ".")(1))
      Dim strAPI As String = "'" & vMixF.description & ControlChars.CrLf & "API.Function("
      strAPI &= ControlChars.Quote & vMixF.function & ControlChars.Quote
      If vMixF.parameters.Input IsNot Nothing AndAlso Not vMixF.parameters.Input.optional Then
        strAPI &= ", Input:=" & ControlChars.Quote & If(cmbInputs.SelectedIndex > -1, cmbInputs.Text, "Input") & ControlChars.Quote
      End If
      If vMixF.parameters.Value IsNot Nothing AndAlso Not vMixF.parameters.Value.optional Then
        strAPI &= ", Value:=" & ControlChars.Quote
        If vMixF.parameters.Value.composites Is Nothing Then
          strAPI &= "My Value"
        Else
          Dim bteComposites As Byte = vMixF.parameters.Value.composites.Count - 1
          For bteCnt = 0 To bteComposites
            strAPI &= vMixF.parameters.Value.composites.Item(bteCnt).type & ":" & vMixF.parameters.Value.composites.Item(bteCnt).description & If(bteCnt < bteComposites, ",", String.Empty)
          Next
        End If
        strAPI &= ControlChars.Quote
      End If
      If vMixF.parameters.Channel IsNot Nothing AndAlso Not vMixF.parameters.Channel.optional Then
        strAPI &= ", Channel:=" & ControlChars.Quote & vMixF.parameters.Channel.type & ":" & vMixF.parameters.Channel.description & ControlChars.Quote
      End If
      If vMixF.parameters.Duration IsNot Nothing AndAlso Not vMixF.parameters.Duration.optional Then
        strAPI &= ", Duration:=" & ControlChars.Quote & vMixF.parameters.Duration.type & ":" & vMixF.parameters.Duration.description & ControlChars.Quote
      End If
      If vMixF.parameters.Duration IsNot Nothing AndAlso Not vMixF.parameters.Duration.optional Then
        strAPI &= ", Duration:=" & ControlChars.Quote & vMixF.parameters.Duration.type & ":" & vMixF.parameters.Duration.description & ControlChars.Quote
      End If
      If vMixF.parameters.SelectedIndex IsNot Nothing AndAlso Not vMixF.parameters.SelectedIndex.optional Then
        strAPI &= ", SelectedIndex:=" & ControlChars.Quote & vMixF.parameters.SelectedIndex.type & ":" & vMixF.parameters.SelectedIndex.description & ControlChars.Quote
      End If
      If vMixF.parameters.SelectedValue IsNot Nothing AndAlso Not vMixF.parameters.SelectedValue.optional Then
        strAPI &= ", SelectedValue:=" & ControlChars.Quote & vMixF.parameters.SelectedValue.type & ":" & vMixF.parameters.SelectedValue.description & ControlChars.Quote
      End If
      If vMixF.parameters.SelectedName IsNot Nothing AndAlso Not vMixF.parameters.SelectedName.optional Then
        Dim strSelectedName As String = vMixF.parameters.SelectedName.type & ":" & vMixF.parameters.SelectedName.description
        If cmbTextFields.SelectedIndex > -1 Then
          strSelectedName = cmbTextFields.Text
        End If
        strAPI &= ", SelectedName:=" & ControlChars.Quote & strSelectedName & ControlChars.Quote
      End If
      strAPI &= ")"
      Dim uint As List(Of Integer) = txtIDE.FindLines(e.Item.Text, System.Text.RegularExpressions.RegexOptions.None)
      txtIDE.Text = txtIDE.Text.Replace(e.Item.Text, strAPI)
      txtIDE.SetSelectedLine(uint(0) + 2)
    End If
  End Sub
  Private Function GetDataFromWeb(ByVal strURL As String, Optional ByVal shtMSeconds As Short = -1) As Task(Of String)
    Dim client As HttpClient = New HttpClient()
    Dim tsk As Task = client.GetStringAsync(New Uri(strURL))
    Try
      tsk.Wait(shtMSeconds)
    Catch ex As Exception
    End Try
    Return tsk
  End Function
  Private Sub btnApi_Click(sender As Object, e As EventArgs) Handles btnApi.Click
    Dim strAPI As Task(Of String) = GetDataFromWeb(txtApi.Text)
    If Not strAPI.IsFaulted Then
      xmlDoc = New XmlDocument
      xmlDoc.LoadXml(strAPI.Result)
      cmbInputs.Items.Clear()
      cmbTextFields.Items.Clear()
      For Each xmlEInput As XmlElement In xmlDoc.SelectSingleNode("/vmix/inputs")
        cmbInputs.Items.Add(xmlEInput.Attributes("title").Value)
      Next
    Else
      MessageBox.Show(Me, "Can't establish connection to vMix", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub

  Private Sub cmbInputs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbInputs.SelectedIndexChanged
    Dim xnList As XmlNodeList = xmlDoc.SelectSingleNode("/vmix/inputs/input[@title='" & cmbInputs.Text & "'][@type='GT']").ChildNodes
    If xnList.Count > 0 Then
      For Each xn As XmlNode In xnList
        If xn.Name = "text" Then
          cmbTextFields.Items.Add(xn.Attributes("name").Value)
        End If
      Next
    End If
  End Sub
End Class
