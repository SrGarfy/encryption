   M S B A M L   `   `   `  ����  DataProtectionVisualization    Encryption.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  	3DES-EDE3��5   	   $��356.686��6    � SizeToContent$ Height=�6+   $��363.117��6B   .��5      �� $��15q�6   .+�5
   
   � $��0,10,0,0q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��5 �6#   �� 5      $��* �6#   5      �� 5   
   $��0,0,22,0q�6   $	��167��6'   .+�5      ]� $��0,5,0,0q�6   .+�5      �� -   5         ��Name$ LabelInputLine��5   .   $
��Left=�6   $��
Input data��6F   $��Center=�5      
������6.   �� 5      -   5         ��Name$ TextBoxInputLine��5      $��Center=�64   $��21��6V   5      ]� 5      $��0,5,0,0q�6   .+�5      �� -   5        $ LabelFirstKey��5   .   $
��Left=�6   $��Key #1��6E   $��Center=�5      
������6.   �� 5      -   5        $ TextBoxFirstKey��5      $��Center=�63   $��20��6U   5      ]� 5      $��0,5,0,0q�6   .+�5      �� -   5        $ LabelSecondKey��5   .   $
��Left=�6   $��Key #2��6F   $��Center=�5      
������6.   �� 5      -   5        $ TextBoxSecondKey��5      $��Center=�64   $��21��6V   5       ]� 5!      $��0,5,0,0q�6   .+�5"      �� -   5        $ LabelThirdKey��5"   .   $
��Left=�6   $��Key #3��6E   $��Center=�5#      
������6.   �� 5$      -   5        $ TextBoxThirdKey��5$      $��Center=�63   $��20��6U   5%      	� 5&      -	   5         	�Name$  RadioButtonInputLineInText��5&   9    	� 	GroupName$ GroupTypeInputLine��6   $
��Text��6]   
������$��0,5,0,0q�5'   #   	� 5(      -
   5        $ RadioButtonInputLineInHex��5(   9   $ GroupTypeInputLine��6   $	��Hex��6\   
������$��0,5,0,0q�5)   #   5*      �� 5+   
   -   5        $��Encrypt��5+      $��23��6A   �� 5,   
   -   5        $��Decrypt��5,      $��21��6A   �� 5-   
   -   5        $ LabelThirdKey_Copy��5-      $��Output data��6,   $��Center=�5.   
   
������$��	0,0,229,0q�6D   �� 5/   
   -   5        $ TextBoxOutputLine��5/       �� 
IsReadOnly . $��Center=�50   
   $��Center=�6,   $��25��6P   $
��10,0q�6\   51      52      