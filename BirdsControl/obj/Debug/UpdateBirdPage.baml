   M S B A M L   `   `   `  ����G  CBirdsControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BirdsControlBirdsControl  5      !    BirdsControl.UpdateBirdPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:BirdsControl     5        N� Title$  UpdateBirdPage��5	      .��5      � .+�5   
   �� -   5         ��Name$ species_label��5      $��	Species: ��6'   $
��Left=�6;   $��	10,64,0,0q�6V   $	��Top=�6i    J� RenderTransformOrigin$ -3.882,-0.268&�6�   $��77��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 5   
   -   5         ��Name$ speciesComboBox��5      $
��Left=�5      $��
162,66,0,0q�5      $	��Top=�5      $	��150��5      .@�5      �� $��American Gouldian��6   �� 5      $��European Gouldian��6   �� 5      $��Australian Gouldian��6   5      �� 5   
   -   5        $ subspecies_label��5      $��Subspecies: ��6*   $
��Left=�6A   $��
10,107,0,0q�6\   $	��Top=�6p   $ -3.882,-0.268&�6�   $	��101��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��33��6�   �� 5   
   -   5        $ subComboBox��5      $
��Left=�5      $��162,115,0,0q�5      $	��Top=�5      $	��150��5      5      �� 5   
   -   5        $ hatch_label��5      $��Hatch Date: ��6%   $
��Left=�6<   $��
10,153,0,0q�6W   $	��Top=�6k   $ -3.882,-0.268&�6�   $	��111��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��32��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 
datePicker��5      $
��Left=�6)   $��162,155,0,0q�6D   $	��Top=�6Y   $	��150��6q   $��26��6}   6�   �� 5    
   -   5        $ 	sex_label��5       $��Sex: ��6#   $
��Left=�63   $��
10,198,0,0q�6N   $	��Top=�6b   $ -3.882,-0.268&�6z   $��77��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 5!   
   -   5        $ sexComboBox��5!      $
��Left=�5"      $��162,200,0,0q�5#      $	��Top=�5$      $	��150��5%      .@�5&      �� $
��Male��6   �� 5'      $��Female��6   5(      �� 5)   
   -	   5        $ 
cage_label��5)      $��Cage Number: ��6$   $
��Left=�6<   $��
10,242,0,0q�6W   $	��Top=�6k   $ -3.882,-0.268&�6�   $	��124��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $��34��6�   �� 5*   
   -
   5         ��Name$ cage_tb��5*      $
��Left=�6#   $��162,247,0,0q�6>    �� TextWrapping$
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��150��6�   $��16(�6�   $��Microsoft New Tai Lue)�6�   $ 0.896,0.491&�6�   $��24��6�   �� 5+   
   -   5         ��Name$ Update_bird��5+      $��Update Bird��5,      $
��Left=�5-      $��200,287,0,0q�5.      $	��Top=�5/      $	��115��50      $��30��6   51      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ gridBird��52      
������ $��Center=�6>   $��
0,337,0,10q�6[   $	��780��6o   6{   �� 53   
   -   5        $ 
Load_Birds��53      $��
Load Birds��54      $
��Left=�55      $��353,287,0,0q�56      $	��Top=�57      $	��115��58      $��30��6   59      �� 5:   
   -   5        $ label��5:      $��Update Bird��6   $��35(�65   $
��Left=�6C   $��	10,-1,0,0q�6^   $	��Top=�6q   $��64��6�   $	��206��6�   �� 5;   
   -   5        $ Delete_bird��5;      $��Delete Bird��5<      $
��Left=�5=      $��
60,287,0,0q�5>      $	��Top=�5?      $	��115��5@      $��30��6   5A      �� 5B   
   $��565,26,20,269q�6   $��/birds2.jpg��6'   5C      5D      