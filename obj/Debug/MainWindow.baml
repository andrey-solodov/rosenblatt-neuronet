   M S B A M L   `   `   `  ����M  IRosenblattNeuroNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:RosenblattNeuroNetRosenblattNeuroNet  5   	   #    RosenblattNeuroNet.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:RosenblattNeuroNet     5   	     � Title$8  2Нейронная сеть Розенблатта��5   	   $	��500��6,   $	��700��69    � WindowStyle$
 None=�6F   
������� � WindowStartupLocation$ CenterScreen=�6m      VS2012WindowStyle#��[  5	   	   .��5      ]� .+�5   
   �� $��Bottom=�5      $��24��5      .@�5      �� $��3,0,0,0q�6   Ready60   �� 5      $��Right=�6   .��5      ��  J� Opacity$
 0.75Q�6   5      5      � 5   
    � ShowGridLines .  � RowDefinitions 5      �� 5      6"   �� 5      6"    � ColumnDefinitions 5      �� 5      $	��200 �6#   61   �� 5      6%   �� 5      6%   .+�5      �� -   5         ��Name$ BtRecognize��5       K� ZIndex$ 1��6*   $��2��6;   $��0��6K   $��Распознать��6X   $��30��6m   $��Bottom=�6y   $��Right=�6�   $��70��6�   ���	#FFD2D8DC���	#FF46545D$��0,0,10,5q�6�   6�   �� 5      -   5        $ BtCleanUpCnv��5      $ 1��6+     IconCleanUp#��[ 6<   $��1��6c   $��30��6t   $��Bottom=�6�   $��Right=�6�   $��30��6�   ���	#FFFCFDFD���	#FF46545D$��0,0,5,5q�6�   6  � 5#      $	��200��6   $
��Left=�6   ���	#FFCDCCBE$��0��6Q   $��2��6a   .+�5$      �� $0��*Скорость обучения сети��6   $
��Left=�69   $��5,5,0,0q�6T   $	��Top=�6e   �� 5%      $8��2Пороговое значение нейрона��6   $
��Left=�6=   $��5,65,0,0q�6X   $	��Top=�6j   �� 5&      $R��LКоличество нейронов 
промежуточного слоя��6   $
��Left=�6O   $��	5,125,0,0q�6j   $	��Top=�6}   $	��154��6�   $��42��6�   �� 5'      $
��Left=�6   $��23��65   $��	10,30,0,0q�6A   	 �� TextWrapping$
	 Wrap=�6T   $��TextBox��6h   $	��Top=�6w   $	��140��6�   �� 5(      $
��Left=�6   $��23��65   $��	10,91,0,0q�6A   $
	 Wrap=�6T   $��TextBox��6h   $	��Top=�6w   $	��140��6�   �� 5)      $
��Left=�6   $��23��65   $��	9,167,0,0q�6A   $
	 Wrap=�6T   $��TextBox��6h   $	��Top=�6w   $	��140��6�   5*      �� 5+      -   5        
 ��Name$
 CanvasUserDrawing��5+      $��1��61   $��Stretch=�6A   $��Stretch=�6`   
�������$��5,0,2,0q�6�   6  �� 5,      $��2��6   $��Stretch=�6&   $��Stretch=�6E   
�������$��2,0,5,0q�6s   �� 5-      $��Button��6   $��2��6&   $
��Left=�66   $��157,182,0,0q�6Q   $��1��6f   $	��Top=�6s   $��75��6�   50      53      54      