   M S B A M L   `   `   `  ����?  ;Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ShopShop  5   	       Shop.DiscountCards   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Shop     5   	   -   5          � Title$  DiscountCards��5   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      .+�5   
   �� $��recources\5606747.jpg��6   $��UniformToFill=�6/   $��5��6G   �� 5   
   
����� �.+�5      �� $	��150��6   $��0q�6"   ��5      �� 5      $��Работники��6    $
��Wrap=�5       5      �� 5      $	��150��6   $��0q�6"   ��5      �� 5      $��Товары��6    $
��Wrap=�5       5      �� 5       $	��150��6   $��0q�6"   ��5!      �� 5"      $#��Скидочные карты��6    $
��Wrap=�5#       5%      5(      � 5)   
   $��1��6    5*      �� 5,      �� 5-      $
��2.5* �6#   �� 5.      �� 5/      $
��0.4* �6#    � RowDefinitions 51      �� 52      $
��0.4* �6    �� 53      $
��2.5* �6    �� 54      .+�56      �� -   5        $��3��56      
������ .��57      �� $��recources\closeBt.png��6   58      �� 5:      $��1��6   $��0��6(   $��4��68   .��5;      &   System.Windows.Controls.DataGrid  -   5          Name$ cards��5;         
IsReadOnly .    AutoGenerateColumns .  	   Columns	 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Имя��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ��  �� Path$
 name�   ElementStyle 5@      �� 5A   "    �� 
TargetType" ��6(   .�5B   &   ��  �� Property � �� �� Value$
 Wrap=�6E   6T   5C   #   5E        5F      $
 Телефон��6-   $ * 6]    6>   �� $ phone� 5G      �� 5H   "   " ��6(   .�5I   &   ��  � ��$
 Wrap=�6E   6T   5J   #   5L        5M      $
 Размер скидки��6-   $ * 6f    6D   �� $ discount� 5N      �� 5O   "   " ��6(   .�5P   &   ��  � ��$
 Wrap=�6E   6T   5Q   #   5S      5U      5V      �� 5W      $��1��6   $��2��6)   .+�5X      �� -   5         ��Name$ searchRequest��5X      �� 5Y      -   5        $��
Поиск��5Y      $��5q�68   $��Center=�6C   $��30��6^   5Z      5[      5\      5]      