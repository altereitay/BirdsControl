   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      G CBirdsControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BirdsControlBirdsControl 5         BirdsControl.AddBirdPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6sys&clr-namespace:System;assembly=mscorlib     5      ,localclr-namespace:BirdsControl     5        N� Title$  AddBirdPage��5       N� FontSize$ 16(�5      .��5      � .+�5   
   �� -   5         ��Name$ species_label��5      $��	Species: ��6'   $
��Left=�6;   $��	22,86,0,0q�6V   $	��Top=�6i    J� RenderTransformOrigin$ -3.882,-0.268&�6�   $��77��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 5   
   -   5         ��Name$ speciesComboBox��5      $
��Left=�5      $��
174,84,0,0q�5      $	��Top=�5      $	��150��5      .@�5      �� $��American Gouldian��6   �� 5      $��European Gouldian��6   �� 5      $��Australian Gouldian��6   5      �� 5   
   -   5        $ subspecies_label��5      $��Subspecies: ��6*   $
��Left=�6B   $��
22,129,0,0q�6]   $	��Top=�6q   $ -3.882,-0.268&�6�   $	��101��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��33��6�   �� 5   
   -   5        $ subComboBox��5      $
��Left=�5      $��174,132,0,0q�5      $	��Top=�5      $	��150��5      5       �� 5!   
   -   5        $ hatch_label��5!      $��Hatch Date: ��6%   $
��Left=�6=   $��
22,175,0,0q�6X   $	��Top=�6l   $ -3.882,-0.268&�6�   $	��111��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��32��6�   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ 
datePicker��5"      $
��Left=�5#      $��174,177,0,0q�5$      $	��Top=�5%      $	��150��5&      $��26��5'      5(      �� 5)   
   -   5        $ 	sex_label��5)      $��Sex: ��6#   $
��Left=�64   $��
22,220,0,0q�6O   $	��Top=�6c   $ -3.882,-0.268&�6{   $��77��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 5*   
   -   5        $ sexComboBox��5*      $
��Left=�5+      $��174,225,0,0q�5,      $	��Top=�5-      $	��150��5.      .@�5/      �� $
��Male��6   �� 50      $��Female��6   51      �� 52   
   -	   5        $ 
cage_label��52      $��Cage Number: ��6$   $
��Left=�6=   $��
22,264,0,0q�6X   $	��Top=�6l   $ -3.882,-0.268&�6�   $	��124��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 53   
   -
   5         ��Name$ cage_tb��53      $
��Left=�6#   $��174,269,0,0q�6>    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��150��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $ 0.896,0.491&�6�   $��24��6�   �� 54   
   -   5         ��Name$ AddBird_btn��54      $��Create Bird��6&   $
��Left=�6<   $��213,307,0,0q�6W   $	��Top=�6l   $	��111��6�   $��30��6�   55      &   System.Windows.Controls.DataGrid  56   
   -   5        	  Name$	 gridBird��56      
������ $��Center=�6>   $��
0,342,0,10q�6[   $	��780��6o   �� 57   
   -   5        $ label��57      $��Add Bird��6   $��35(�62   $
��Left=�6@   $��	22,10,0,0q�6[   $	��Top=�6n   $��64��6�   $	��162��6�   �� 58   
   $��/birds1.jpeg��6   $��589,31,24,247q�6&   59      5:      