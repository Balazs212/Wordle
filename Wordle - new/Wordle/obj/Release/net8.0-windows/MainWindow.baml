   M S B A M L   `   `   `  ���� A  =Wordle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WordleWordle      Wordle.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Wordle       � Title$  Wordle��$	��450��$	��800��.��� ����  �� ImageSource$ gradient.png��.+� � -     �Name$ 	MainFrame��  � NavigationUIVisibility$ Hidden=��� -    ��Name$ WordleStartScreen��.+��� $��WORDLE��$��80(�$��Center=�$	��Top=�
���   �
�������$��Arial)�$��
0,10,0,100q�$��	10,0,10,0q��� $��Select word lenght:��
���   �
�������$��Arial)�$��Center=�$	��173��$��Center=���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -    ��Name$ DecreaseButton��$��-��$��50��$��5q�
���   �
�������$��Arial)�$y�Visible=��� -    ��Name$ NumberTextBox��$��47��$��Center=�$��5q�
���   �
�������$��Arial)�$��4�� �� 
IsReadOnly$
 True���� -   $ IncreaseButton��$��+��$��50��$��5q�
���   �
�������$��Arial)�$y�Visible=��� -   	 ��Name$	 LanSel��$	��178��$��Arial)�$��25��$��2q�.@��� 

 � Tag$
 en��.��	English�� $
 zh��.��	Chinese�� $
 es��.��	Espanol�� $
 de��.��German�� $
 fr��.��French�� $
 it��.��	Italien�� -   $ 	ApiButton��$��Get word from API��$	��178��
���   �$��2q�
�������$��Arial)�$��25���� -   $ WordleStartButton��$��START��$	��178��
���   �
�������$��Arial)�$��25���� $*��$Red = Correct letter, Wrong position��
���  ��$��Arial)�$��Center=��� $.��(Green = Correct letter, Correct position��
��� � �$��Arial)�$��Center=��� -	    ��Name$ APIReadytext��$��	API ready��
�������$��Arial)�$��Center=�$y�	Collapsed=�