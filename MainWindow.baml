   M S B A M L   `   `   `  ����  WpfApp1    FileLoaderApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  File Loader��5   	   $	��350��6   $	��600��6*   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��40 �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��PATH:��6   $
��Bold"�6!   $��0��63   $��0��6@   $��Center=�6P   �� 5   
   -   5         ��Name$ PathTextBox��5      $��0��6'   $��1��64   $��5q�6D   �� 5   
   -   5        $
��OPEN��5      $��0��6    $��2��6-   $��70��6=   $��5q�6H   ���#1E90FF6h   �� 5   
   $��DATA:��6   $
��Bold"�6!   $��2��63   $��0��6@   $	��Top=�6P   �� 5   
   -   5        $ DataTextBox��5      $��2��6'   $��1��64   $��2��6D    �� AcceptsReturn$
 True��6U    �� TextWrapping$
 Wrap=�6j   " �� VerticalScrollBarVisibility$
 Auto=�5      $��5q�65   �� 5   
   -   5        $
��SEND��5      $��4��6    $��2��6-   $��70��6=   $��5q�6H   ���#1E90FF6h   5      5      