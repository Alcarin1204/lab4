   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   5clr-namespace:WpfApp1.ViewModelWpfApp1.ViewModel  6-       WpfApp1.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   5	ViewModelclr-namespace:WpfApp1.ViewModel     6-     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5	      %  WpfApp1.ViewModel.CursViewModel  5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��117* �6   �� 5      $
��302* �6   .+�5   
   �� $��0��6   $��0��6#    �� SelectedIndex$ 0��60    �� DisplayMemberPath$ Name1��6n   $��0,0,0,67q�6�    �� SelectedItem 6B   ��  �� Path$ UserSelected1���6�   �� $ 
ValuteList�6�   (  "System.Windows.Controls.DatePicker  5   
   $��1��6   $��0��6%   $��0,0,0,67q�6P      SelectedDate 62   �� *Date+6P   �� 5   
   $��2��6   $��0��6#   $ 0��60   $ Name1��6n   $��0,0,0,67q�6�    6B   �� $ UserSelected2���6�   �� $ 
ValuteList�6�   �� 5   
   $��0��6   $��0,50,0,0q�6>   $��2��6P   ��6"   �� *
User_Value+6P   �� 5   
   $��2��6   $��0,50,0,0q�6C   $��2��6U   ��6"   �� *Converted_Value+6U   5      5       