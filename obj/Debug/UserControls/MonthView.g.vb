﻿#ExternalChecksum("..\..\..\UserControls\MonthView.xaml","{8829d00f-11b8-4213-878b-770e8597ac16}","6456EA1952C28AE303F13D6D968231F0D701D5013A0E7C49584467237FEE5C52")
'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''MonthView
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class MonthView
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\..\UserControls\MonthView.xaml",13)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MonthGoPrev As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\UserControls\MonthView.xaml",19)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MonthGoNext As System.Windows.Controls.Image
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\UserControls\MonthView.xaml",21)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MonthYearLabel As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\UserControls\MonthView.xaml",45)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents MonthViewGrid As System.Windows.Controls.Grid
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/QuickWPFMonthCalendar;component/usercontrols/monthview.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\UserControls\MonthView.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.MonthGoPrev = CType(target,System.Windows.Controls.Image)
            
            #ExternalSource("..\..\..\UserControls\MonthView.xaml",14)
            AddHandler Me.MonthGoPrev.MouseLeftButtonUp, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.MonthGoPrev_MouseLeftButtonUp)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.MonthGoNext = CType(target,System.Windows.Controls.Image)
            
            #ExternalSource("..\..\..\UserControls\MonthView.xaml",20)
            AddHandler Me.MonthGoNext.MouseLeftButtonUp, New System.Windows.Input.MouseButtonEventHandler(AddressOf Me.MonthGoNext_MouseLeftButtonUp)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 3) Then
            Me.MonthYearLabel = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 4) Then
            Me.MonthViewGrid = CType(target,System.Windows.Controls.Grid)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

