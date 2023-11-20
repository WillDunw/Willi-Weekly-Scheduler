Imports System.ComponentModel

Public Class AddAppointment
    Implements IWindow
    Private mainWindow As Window1
    Private presenter As Presenter
    Public Sub New(mainWindow As Window1, presenter As Presenter)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mainWindow = mainWindow
        Me.presenter = presenter
        Initialize()

        dtp_startTime.Minimum = DateTime.Today
        dtp_endTime.Minimum = DateTime.Today
    End Sub

    'Only public to allow addCategory to display the new categories when it is closed
    Private Sub Initialize()
        If Not presenter.MustAddCategories Then
            cmb_categories.ItemsSource = presenter.GetCategories()
        Else
            DisplayInfo("There are no event categories yet. You must add some before scheduling events.")
            OpenAddCategoryWindow()
        End If

        dtp_startTime.DefaultValue = DateTime.Today
        dtp_endTime.DefaultValue = DateTime.Today
    End Sub

    Public Sub Window_Closing(sender As Object, e As CancelEventArgs)
        mainWindow.IsEnabled = True
        Presenter.SwitchView(mainWindow)
    End Sub

    Public Sub DisplayError(message As String) Implements IWindow.DisplayError
        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
    End Sub

    Public Sub DisplayInfo(message As String) Implements IWindow.DisplayInfo
        MessageBox.Show(message, "Notice", MessageBoxButton.OK, MessageBoxImage.Asterisk)
    End Sub

    Private Sub OpenAddCategoryWindow()
        Dim addCategoryWindow = New AddCategory(Me, presenter)
        Me.IsEnabled = False
        Presenter.SwitchView(addCategoryWindow)
        addCategoryWindow.Show()
        addCategoryWindow.Topmost = True
    End Sub

    Private Sub btn_addCategory_Click(sender As Object, e As RoutedEventArgs)
        OpenAddCategoryWindow()
    End Sub

    'Genuinely have no idea how the dates work here... but they do wth some DefaultValue setting black magic
    Private Sub btn_addAppointment_Click(sender As Object, e As RoutedEventArgs)
        '+1 because in the databse the ids start at 1 and the combobox they start at 0
        presenter.AddAppointment(txb_subject.Text, dtp_startTime.Text, dtp_endTime.Text, cmb_categories.SelectedIndex + 1)
    End Sub

    Public Sub ResetValues() Implements IWindow.ResetValues
        txb_subject.Text = ""
        cmb_categories.SelectedIndex = -1
        dtp_endTime.Text = ""
        dtp_startTime.Text = ""
    End Sub

    Private Sub dtp_startTime_ValueChanged(sender As Object, e As RoutedPropertyChangedEventArgs(Of Object))
        Dim test As String = dtp_startTime.Text
    End Sub

    Private Sub cmb_categories_DropDownOpened(sender As Object, e As EventArgs)
        Initialize()
    End Sub

    Public Sub DisplaySuccess(message As String) Implements IWindow.DisplaySuccess
        MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub
End Class
