   M S B A M L   `   `   `  ����?  ;Mail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MailMail  5   	       Mail.SelectedMessage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Mail     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   2     � Title$  Message��6	   $	��350��6   $	��600��6&    � WindowStyle$
 None=�6{    � 
ResizeMode$ 	CanResize=�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � ���#242424$��	0,0,0,-10q�6     � RowDefinitions 5   
   �� 5      $	��27* �6   6+   �� 5      $	��52* �6   6+   �� 5      $	��53* �6   6+   �� 5      $
��101* �6   6,   �� 5      $
��117* �6   6,   .+�5   
   �� ���#242424$��24��5      $��Center=�5      62   �� 5   
   -   5         ��Name$
 Exit��5      $��Right=�5      $	��Top=�5      ���	#FF414141$��X��5      $��10(�5      $��24��5      $��	562,0,0,0q�5      $��38��5       6   �� 5"   
   -   5         ��Name$ label��5"      $��Your mail client��5#      $��10,0,0,9q�5$      $	��245��5%      $
��Left=�5&      $	��5,2q�5'      ���	#FFB2B2B25(      �� 5*   
   $��
30,6,30,10q�6    �� RadiusY$ 20��5+       �� RadiusX$ 20��5,      $��4��5-      $��1��5.      ��50      �� 51      	 �� Color$	 	#FFFFC107��6"   54      �� 56   
   -   5        
 ��Name$
 TitleMessage��56      $��85,19,105,0q�57       �� TextAlignment$ Center=�58      $��15(�59      ���#242424$��1��5;      �� 5=   
   -   5        $
 
FromAdress��5=      $��85,10,337,17q�5>      $ Center=�5?      $��10(�5@      $��2��5A      �� 5C   
   $��1��6   $��2��5D      $��0,42,0,0q�5E       J� RenderTransformOrigin$ 0.5,0.5&�5F      $	��Top=�5G      $��Center=�5H      $	��430��5I      z�5K      V� 5L      .~�5M      ��  �� ScaleY$ -1Q�6%   �� 5N      �� 5O      T� 5P      5Q      ��5T      �� 5U      $	 #242424��6"   5X      �� 5Y   
   -   5        $

 Body��5Y      $	��159��5Z      $	��430��5[      $	��Top=�5\      $��Center=�5]      $��2��5^      $��0,49,0,0q�5_      $��3��5`      �� 5b   
   -   5        $ 	AnswerBtn��5b         MaterialDesignRaisedButton#��[  5c       � ToolTip$/ )Resource name: MaterialDesignRaisedButton��5d      $��Answer��5e      ���	#FFB2B2B2$��15(�5g      $��4��5h      $��240,59,240,26q�5j      ���	#FF242424{�5i      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType" �5l      5m      5n      