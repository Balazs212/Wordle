   M S B A M L   `   `   `  ����A  =Wordle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WordleWordle  5   	       Wordle.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Wordle     5   	     � Title$  Wordle��5   	   $	��450��6   $	��800��6%   .��5	      � ��5
   
   �� 5       �� ImageSource$ gradient.png��6   .+�5   
    � -   5          �Name$ 	MainFrame��5        � NavigationUIVisibility$ Hidden=�6#   �� 5   
   -   5         ��Name$ WordleStartScreen��5      .+�5      �� $��WORDLE��6   $��80(�6%   $��Center=�63   $	��Top=�6P   
���   �
�������$��Arial)�6�   $��
0,10,0,100q�6�   $��	10,0,10,0q�6�   �� 5      $��Select word lenght:��6   
���   �
�������$��Arial)�6X   $��Center=�6k   $	��173��6�   $��Center=�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� -   5         ��Name$ DecreaseButton��5   �   $��-��6   $��50��6%   $��5q�6M   
���   �
�������$��Arial)�6~   $y�Visible=�6�   �� 5      -   5         ��Name$ NumberTextBox��5      $��47��61   $��Center=�6<   $��5q�6`   
���   �
�������$��Arial)�6�   $��4��6�    �� 
IsReadOnly$
 True��6�   6�   �� 5      -   5        $ IncreaseButton��5   �   $��+��6   $��50��6%   $��5q�6M   
���   �
�������$��Arial)�6~   $y�Visible=�6�   5      �� 5      -   5        	 ��Name$	 LanSel��5      $	��178��6'   $��Arial)�63   $��25��6F   $��2q�6s   .@�5      �� 

 � Tag$
 en��6   .��6(   	English61   �� 5      $
 zh��6   .��6(   	Chinese61   �� 5      $
 es��6   .��6(   	Espanol61   �� 5      $
 de��6   .��6(   German60   �� 5      $
 fr��6   .��6(   French60   �� 5      $
 it��6   .��6(   	Italien61   5      �� 5      -   5        $ 	ApiButton��5      $��Get word from API��6@   $	��178��6\   
���   �$��2q�6{   
�������$��Arial)�6�   $��25��6�   �� 5      -   5        $ WordleStartButton��5      $��START��6P   $	��178��6`   
���   �
�������$��Arial)�6�   $��25��6�   �� 5       $*��$Red = Correct letter, Wrong position��6   
���  ��$��Arial)�6T   $��Center=�6g   6�   �� 5!      $.��(Green = Correct letter, Correct position��6   
��� � �$��Arial)�6Z   $��Center=�6m   6�   �� 5"      -	   5         ��Name$ APIReadytext��5"   (   $��	API ready��6   
�������$��Arial)�6Q   $��Center=�6d   $y�	Collapsed=�6�   6�   5#      5$      5%      