Public Class AddAppointmentWindow
    Implements IWindow
    Public Sub DisplayError(message As String) Implements IWindow.DisplayError
        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
    End Sub

    Public Sub DisplayInfo(message As String) Implements IWindow.DisplayInfo
        MessageBox.Show(message, "Notice", MessageBoxButton.OK, MessageBoxImage.Asterisk)
    End Sub
    Public Sub ResetValues() Implements IWindow.ResetValues
        txb_subject.Text = ""
        cmb_categories.SelectedIndex = -1
        dtp_endTime.Text = ""
        dtp_startTime.Text = ""
    End Sub

    Public Sub DisplaySuccess(message As String) Implements IWindow.DisplaySuccess
        Throw New NotImplementedException()
    End Sub

    Private Sub OpenAddCategoryWindow()
        Dim addCategoryWindow = New AddCategory(Me, Presenter)
        Me.IsEnabled = False
        Presenter.SwitchView(addCategoryWindow)
        addCategoryWindow.Show()
        addCategoryWindow.Topmost = True
    End Sub
End Class
