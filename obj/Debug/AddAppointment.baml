   M S B A M L   `   `   `  ����P  LQuickWPFMonthCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:QuickWPFMonthCalendarQuickWPFMonthCalendar  5   	   *    $QuickWPFMonthCalendar.AddAppointment   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:QuickWPFMonthCalendar     5   	   X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  AddAppointment��5	   	   $	��450��6    $	��800��6-   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��2��6   $��Center=�6(   $��36(�6E   $
��Bold"�6S   	Add Event6p   �� 5   
   $��1��6   $��2��6   $��Center=�61   $	��Top=�6N   $��25��6f   $��16(�6u   $��Subject��6�   $
��Bold"�6�   6�   �� 5   
   -   5        $��txb_subject��5      $��1��6%   $��2��62   $	��100��6F   $��25��6U   $��Stretch=�6d   $��Center=�6�   $��Center=�6�   $��	20,0,20,0q�6�   6�   �� 5   
   $��2��6   $��2��6   $��Center=�61   $	��Top=�6N   $��Category��6f   $��14(�6y   $
��Bold"�6�   6�   �� 5    
   -   5        $��cmb_categories��5       $��2��6)   $��2��66   $��Center=�6J    �� DisplayMemberPath$ Title��6e   $	��195��5!   B   $��25��6Q   $��	20,0,20,0q�6`   �� 5#   
   $��3��6   $��Center=�6   $	��Top=�6:   $��
Start Time��6R   $��14(�6g   $
��Bold"�6u   6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5$   
   -   5        $��dtp_endTime��5%      $��1��5$   H   &   Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6X      FormatString$ dddd MMMM dd yyyy HH:mm��6h   $��3��5%   1   $��Center=�6>   $��15��6Y   $��	15,0,15,0q�6g   $��15��6z   �� 5&   
   $��End Time��6   $��14(�6#   $
��Bold"�61   $��Center=�6C   $	��Top=�6`   $��3��6x   $��1��6�   6�     5'   
   -   5        $��dtp_startTime��5'      $��3��63   $ Custom=�6@   $ dddd MMMM dd yyyy HH:mm��6P   $��Center=�5(      $��25��69   $��	15,0,15,0q�6H   6]   �� 5*   
   -   5        $��btn_addAppointment��5*      $��4��6L   $��Center=�6Y   $��	20,0,20,0q�6t   $��25��6�   $��Add Appointment��6�   6�   �� 5+   
   -   5        $��btn_addCategory��5+      $��4��6F   $��1��6S   $��Center=�6c   $��25��6~   $��	20,0,20,0q�6�   $��Add Category��6�   6�   5-      5.      