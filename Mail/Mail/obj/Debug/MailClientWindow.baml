   M S B A M L   `   `   `  ����?  ;Mail, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MailMail  5   	       Mail.MailClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Mail     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � Title$  MailClientWindow��5   	   $	��450��6"   $	��800��6/    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62   .��5      � -   5        ���#242424.+�5   
   �� ���#242424$��25��5      $	��Top=�5      6/   �� 5   
   -   5         ��Name$
 Exit��5      $��Right=�5      $	��Top=�5      ���	#FF414141$��X��5      $��10(�5      $��25��5       J� RenderTransformOrigin$ 
0.33,0.488&�6   $��0,1,2,0q�6@   6S   �� 5   
   -   5         ��Name$ label��5      $��Your mail client��5      $��10,0,0,9q�5      $	��245��5      $
��Left=�5      $	��5,2q�5      ���	#FFB2B2B25       �� 5"   
   $	��400��6   $��30,25,30,25q�5#       �� RadiusY$ 20��5$       �� RadiusX$ 20��6!   ��5&      �� 5'      	 �� Color$	 	#FFFFC107��6"   5)      �� 5+   
   $��2��6   ���	#FF414141$��269,30,529,30q�5-      �� 5/   
   -   5        
 ��Name$
 
FolderList��5/      $��43,30,536,30q�50      ���	#FF414141 � ContextMenu 54      �� 55      .@�56      m� -   5        $��SendMessage��56      64   m� 57      $��Message��6   58      5;      �� 5=   
   -   5        $
 MessageList��5=      $��284,46,47,46q�5>      ���	#FF4141415@      5A      5B      