   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   
 HOIGUI   HOIGUI.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$!  Halo Online Installer - GUI��5   	   $��309.168��6-   $	��617��6>    � 
ResizeMode$ NoResize=�6J   $��0q�5   	   (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   �   WindowTransitionsEnabled .     ShowIconOnTitleBar .    ShowMaxRestoreButton .     Flyouts 5      +   %MahApps.Metro.Controls.FlyoutsControl  5   
   .@�5      #   MahApps.Metro.Controls.Flyout  -   5          Name$ yourMahAppFlyout��5         Header$ Settings��69   	   Position$	 Right=�6K   $	��580��6\   .��5      � .+�5      �� $��16(�6    $��25,3,0,0q�6.   	Game Path6K   �� 5      -   5        
 ��Name$

 lbl1��5      $
��Left=�6,   $��29��6G    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��430��6   $��
25,32,30,0q�6�   {�.  6�   �� 5      -   5        $	��...��5      $
��Left=�6+   $��468,32,15,0q�6F   $	��Top=�6[   $��85��6s   6~   �� 5      $��16(�6    $��	25,73,0,0q�6.   	Mods Path6L   �� 5      -   5        $

 lbl2��5      $
��Left=�6,   $��29��6G   $
 Wrap=�6S   $	��Top=�6g   $	��430��6   $��25,102,30,0q�6�   {�.  6�   �� 5      -   5        $	��...��5      $
��Left=�6+   $��468,102,15,0q�6F   $	��Top=�6\   $��85��6t   6   5      5      5         RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5!      d�  � Cursor$
 Hand��6_    d� 	IsChecked 6   ��  �� ElementName$ yourMahAppFlyout�� �� Path$ IsOpen�6_   �� 5#      -   5        .��5$      ��  �� Orientation$ 
Horizontal=�6   .+�5%      �� $��20��6    $��20��6+   ��5&      ��  �� RelativeSource ��  �� AncestorType$ ButtonL�$ 
Foreground� J� OpacityMask 5'      !� 5(       j� Stretch$
 Fill=�6*      appbar_source_pull !� Visual# [  5)      5+      �� 5,      $��4 0 0 0q�6    $��Center=�5-      $��Settings��5.      5/      50      51      .��54      �  � ColumnDefinitions 55   
   �� 56      $
��Auto �6   .+�58   
   �� $
��Left=�6   $	��260��60   $��	13,10,0,0q�6=   $	��Top=�6P   $	��589��6h   .@�59      �� $
��Game��6   $��0,-7,0,7q�6$   $��39��66   $��1��6B   .��5:      � ���	#FFE5E5E5$	��217��6.   $	��Top=�6;    5;      �� 5<      .+�5?      � -   5         �Name$	 pb1��5?   "   $
��Left=�6/   $��
10,100,0,0q�6J   $	��Top=�6^   $	��563��6v   $��26��6�   �� 5@      -	   5        $��Start Download��5@      $
��Left=�66   $��438,135,0,0q�6Q   $	��Top=�6f   $	��135��6~   6�   �� 5A      $��File: ��6   $
��Left=�6-   $��5,71,0,0q�6H   $	��Top=�6Z   �� 5B      $��filename��6   $
��Left=�6/   $��	35,71,0,0q�6J   $	��Top=�6]   �� 5C      $	��0 %��6   $
��Left=�6*   $��
274,99,0,0q�6E   $	��Top=�6Y   5D      5E      �� 5G      $
��Mods��6   $��0,-7,0,7q�6$   $��39��66   $��1��6B   .��5H      � ���	#FFE5E5E5$��0,0,0,-2q�6.   $	��217��6@   $	��Top=�6M   .+�5I      �� -
   5        $��lvUsers��5I      $
��Left=�6.   $	��197��6I   $��	10,10,0,0q�6V   $	��Top=�6i   $	��563��6�    � ContextMenu 5J      �� 5K      .@�5L   "   m� -   5        $��Download this Mod��5L   +   ��5M   &   �� 5N   *    �� EndPoint$ 0.5,1&�6>    �� 
StartPoint$ 0.5,0&�6O   .��5O   .   �  � Color$ White��6;    � Offset$ 0Q�6I   � 5P   .   $ White��6;   $ 1Q�6I   � 5Q   .   $ White��6;   $ 0.245Q�6I   5R   +   5T   #   5U       �� View 5W      �� 5Y      .P�5Z   "   �� $
��Name��63    �� Width$	 250��6A     �� DisplayMemberBinding  6M   �� *Name+�� 5[   "   $��Version��61   $	 150��6B     6N   �� *Ver+�� 5\   "   $��Author��61   $	 168��6A     6M   �� *Auth+5e      5i      5j      5k      5l      5n      5o      