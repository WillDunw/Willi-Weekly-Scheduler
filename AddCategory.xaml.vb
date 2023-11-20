Public Class AddCategory
    Implements IWindow

    Private addAppointmentWindow As AddAppointment
    Private presenter As Presenter
    Public Sub New(addAppointmentWindow As AddAppointment, presenter As Presenter)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.addAppointmentWindow = addAppointmentWindow
        Me.presenter = presenter

        InitializeComboBox()
    End Sub

    Private Sub InitializeComboBox()
        cmb_categoryType.ItemsSource = [Enum].GetValues(GetType(AppointmentCategory.CategoryType))
        cmb_categoryType.SelectedItem = AppointmentCategory.CategoryType.FreeTime
    End Sub

    Public Sub DisplayError(message As String) Implements IWindow.DisplayError
        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error)
    End Sub

    Public Sub DisplayInfo(message As String) Implements IWindow.DisplayInfo
        MessageBox.Show(message, "Notice", MessageBoxButton.OK, MessageBoxImage.Asterisk)
    End Sub

    Public Sub ResetValues() Implements IWindow.ResetValues
        txb_categoryTitle.Text = ""
    End Sub

    Private Sub Window_Closing(sender As Object, e As ComponentModel.CancelEventArgs)
        addAppointmentWindow.IsEnabled = True
        presenter.SwitchView(addAppointmentWindow)
    End Sub

    Private Sub btn_addCategory_Click(sender As Object, e As RoutedEventArgs)
        presenter.AddCategory(txb_categoryTitle.Text, cmb_categoryType.SelectedItem)
    End Sub

    Public Sub DisplaySuccess(message As String) Implements IWindow.DisplaySuccess
        MessageBox.Show(message, "Success", MessageBoxButton.OK, MessageBoxImage.Information)
    End Sub
End Class
